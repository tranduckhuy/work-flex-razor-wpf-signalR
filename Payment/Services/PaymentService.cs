using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using WorkFlex.Domain;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Configs.Momo.Requests;
using WorkFlex.Payment.Configs.VnPay.Configs;
using WorkFlex.Payment.Configs.VnPay.Requests;
using WorkFlex.Payment.Configs.VnPay.Responses;
using WorkFlex.Payment.Configs.ZaloPay.Config;
using WorkFlex.Payment.Configs.ZaloPay.Request;
using WorkFlex.Payment.Configs.ZaloPay.Response;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;
using WorkFlex.Payment.Utils.Constants;
using WorkFlex.Payment.Utils.Extensions;

namespace WorkFlex.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly MomoConfig _momoConfig;
        private readonly ZaloPayConfig _zaloConfig;
        private readonly VnPayConfig _vnPayConfig;
        private readonly AppDbContext _context;

        public PaymentService(IOptions<MomoConfig> momoConfig, IOptions<VnPayConfig> vnpayOptions, IOptions<ZaloPayConfig> zaloConfig, AppDbContext context)
        {
            _momoConfig = momoConfig.Value;
            _vnPayConfig = vnpayOptions.Value;
            _zaloConfig = zaloConfig.Value;
            _context = context;
        }

        public async Task<ApiResponse<PaymentLinkDtos>> CreatePayment(CreatePaymentRequest request)
        {
            var result = new ApiResponse<PaymentLinkDtos>();

            try
            {
                var (affectedRows, paymentId) = await InsertPayment(request);

                if (affectedRows > 0)
                {
                    string paymentUrl = string.Empty;
                    string ipAddress = GenerateRandomIpAddress();

                    switch (request.PaymentDestinationId)
                    {
                        // Payment method is Momo 
                        case nameof(PaymentMethod.MOMO):

                            var momoPayment = new MomoOneTimePaymentRequest
                            {
                                PartnerCode = _momoConfig.PartnerCode,
                                RequestId = paymentId.ToString(),
                                Amount = (long)request.RequiredAmount,
                                OrderId = paymentId.ToString(),
                                OrderInfo = request.PaymentContent,
                                RedirectUrl = _momoConfig.RedirectUrl,
                                IpnUrl = _momoConfig.IpnUrl,
                                RequestType = RequestType.PayWithATM
                            };

                            momoPayment.MakeSignature(_momoConfig.AccessKey, _momoConfig.SecretKey);

                            var (success, message) = momoPayment.GetLink(_momoConfig.PaymentUrl);
                            if (success)
                            {
                                paymentUrl = message;
                            }
                            else
                            {
                                result.Set(false, message);
                                return result;
                            }

                            break;
                        case nameof(PaymentMethod.ZALOPAY):
                            int randomNumber = GetRandomNumber(1000001);
                            var shortPaymentId = paymentId.ToString()[..8];

                            var zaloPayment = new ZaloOneTimePaymentRequest
                            (
                                _zaloConfig.AppId, 
                                _zaloConfig.AppUser, 
                                DateTime.Now.ToString("yyMMdd")  + "_" + shortPaymentId, 
                                DateTime.Now.GetTimeStamp(),
                                (long)request.RequiredAmount!, 
                                request.PaymentContent ?? string.Empty, 
                                "zalopayapp",
                                _zaloConfig.RedirectUrl
                            );
                            zaloPayment.MakeSignature(_zaloConfig.Key1);

                            var (successZalo, messageZalo) = zaloPayment.GetLink(_zaloConfig.PaymentUrl);
                            if (successZalo)
                            {
                                paymentUrl = messageZalo;
                            }
                            else
                            {
                                result.Set(false, messageZalo);
                                return result;
                            }

                            break;
                        case nameof(PaymentMethod.VNPAY):

                            var vnPayPayment = new VnPayOneTimePaymentRequest
                            {
                                vnp_Version = _vnPayConfig.Version,
                                vnp_TmnCode = _vnPayConfig.TmnCode,
                                vnp_Amount = (int)request.RequiredAmount * 100,
                                vnp_OrderInfo = request.PaymentContent ?? string.Empty,
                                vnp_OrderType = "130005",
                                vnp_ReturnUrl = _vnPayConfig.ReturnUrl,
                                vnp_TxnRef = paymentId.ToString(),
                                vnp_IpAddr = ipAddress,
                                vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss"),
                                vnp_ExpireDate = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"),
                                vnp_CurrCode = "VND",
                                vnp_Locale = "vn"
                            };

                            paymentUrl = vnPayPayment.GetLink(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);
                            break;

                        default:
                            result.Set(false, MessageContants.PaymentMethodNotSupported);
                            break;
                    }

                    result.Set(true, MessageContants.Success, new PaymentLinkDtos
                    {
                        PaymentId = paymentId.ToString(),
                        PaymentUrl = paymentUrl
                    });
                }
                else
                {
                    result.Set(false, MessageContants.Error);
                    result.Errors.Add(new BaseError()
                    {
                        Code = "Sql",
                        Message = "Insert payment failed"
                    });
                }
            }
            catch (Exception ex)
            {
                result.Set(false, MessageContants.Error);
                result.Errors.Add(new BaseError()
                {
                    Code = MessageContants.Exception,
                    Message = ex.Message
                });
            }

            return result;
        }

        public async Task<ApiResponse<(PaymentReturnDto, string)>> ProcessMomoPaymentReturn(MomoOneTimePaymentResultRequest request)
        {
            return await ProcessPaymentReturn(
                request,
                req => req.IsValidSignature(_momoConfig.AccessKey, _momoConfig.SecretKey), // Validate signature for Momo
                req => Guid.Parse(req.OrderId!), // Get payment ID from the order ID
                req => req.ResultCode.ToString(), // Get the result code from the request
                req => req.ResultCode == 0 ? "00" : "10", // If ResultCode == 0, it is considered successful
                _momoConfig.RedirectWebUrl // Redirect URL after payment processing
            );
        }

        public async Task<ApiResponse<(PaymentReturnDto, string)>> ProcessVnpayPaymentReturn(VnPayOneTimePaymentCreateLinkResponse response)
        {
            return await ProcessPaymentReturn(
                response,
                request => request.isValidSignature(_vnPayConfig.HashSecret), // Validate signature for VnPay
                request => Guid.Parse(request.vnp_TxnRef), // Get payment ID from VnPay transaction reference
                request => request.vnp_ResponseCode, // Get response code from the VnPay response
                request => request.vnp_TransactionStatus, // Get transaction status from VnPay response
                _vnPayConfig.RedirectWebUrl // Redirect URL after payment processing
            );
        }

        private async Task<ApiResponse<(PaymentReturnDto, string)>> ProcessPaymentReturn<T>(
            T request, Func<T, bool> validateSignature, Func<T, Guid> getPaymentId,
            Func<T, string> getStatusCode, Func<T, string> getTransactionStatus,
            string redirectWebUrl, SubscriptionType subscriptionType = SubscriptionType.Premium)
        {
            var result = new ApiResponse<(PaymentReturnDto, string)>() { Success = false }; // Initialize response result
            var resultData = new PaymentReturnDto(); // Initialize payment return data

            try
            {
                // Validate signature and ensure that the payment ID can be parsed from the request
                if (!validateSignature(request) || !Guid.TryParse(getPaymentId(request).ToString(), out Guid paymentId))
                {
                    // If validation fails or payment ID is invalid, return error response
                    return CreateErrorResponse(result, resultData, "11", "Can't find payment at payment service or Invalid signature in response");
                }

                // Retrieve payment details from the database using the payment ID
                var payment = await _context.Payments.FindAsync(paymentId);
                if (payment == null)
                {
                    // If no payment record is found, return error response
                    return CreateErrorResponse(result, resultData, "11", "Payment not found");
                }

                // Check if both status code and transaction status indicate a successful transaction
                if (getStatusCode(request) == "00" && getTransactionStatus(request) == "00")
                {
                    // If successful, mark the payment as paid in the database
                    payment.IsPaid = true;
                    await _context.SaveChangesAsync();

                    // Update the user's subscription type if a user record is found
                    var user = await _context.Users.FindAsync(payment.UserId);
                    if (user != null)
                    {
                        user.SubscriptionType = subscriptionType; // Assign subscription type
                        await _context.SaveChangesAsync();
                    }

                    // Prepare successful payment details in the response
                    resultData.PaymentStatus = "00";
                    resultData.PaymentId = payment.Id.ToString();
                    resultData.Signature = Guid.NewGuid().ToString(); // Generate a new signature for the payment
                    result.Set(true, MessageContants.OK, (resultData, redirectWebUrl)); // Set success response with payment data and redirect URL
                }
                else
                {
                    // If payment failed, set the error status and message from the transaction response
                    resultData.PaymentStatus = getTransactionStatus(request);
                    resultData.PaymentMessage = GetErrorMessage(getStatusCode(request));
                    result.Set(false, resultData.PaymentMessage, (resultData, redirectWebUrl)); // Return error response
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, log the exception and return a generic error response
                result.Set(false, MessageContants.Error);
                result.Errors.Add(new BaseError
                {
                    Code = MessageContants.Exception,
                    Message = ex.Message // Add exception details to the error response
                });
            }

            return result;
        }

        public async Task<ApiResponse<(PaymentReturnDto, string)>> ProcessZaloPaymentReturn(ZaloOneTimePaymentResultRequest request)
        {
            string redirectWebUrl = _zaloConfig.RedirectWebUrl;
            var result = new ApiResponse<(PaymentReturnDto, string)>
            {
                Success = false
            };

            try
            {
                var resultData = new PaymentReturnDto();

                // Slpit paymentId from AppTransId
                var appTransIdParts = request.AppTransId?.Split('_');
                if (appTransIdParts != null && appTransIdParts.Length > 1)
                {
                    var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id.ToString().Contains(appTransIdParts[1]));

                    if (payment != null)
                    {
                        if (request.Status == 1)
                        {
                            payment.IsPaid = request.Status == 1;
                            await _context.SaveChangesAsync();

                            resultData.PaymentStatus = "00";
                            resultData.PaymentId = payment.Id.ToString();
                            resultData.Signature = Guid.NewGuid().ToString();

                            result.Set(true, MessageContants.OK, (resultData, redirectWebUrl));
                        }
                        else
                        {
                            resultData.PaymentStatus = "10";
                            resultData.PaymentMessage = "Payment process failed";
                        }
                    }
                    else
                    {
                        resultData.PaymentStatus = "11";
                        resultData.PaymentMessage = "Payment not found in the database.";
                    }
                }
                else
                {
                    resultData.PaymentStatus = "11";
                    resultData.PaymentMessage = "Invalid payment ID format in Description or missing payment ID.";
                }
            }
            catch (Exception ex)
            {
                result.Set(false, MessageContants.Error);
                result.Errors.Add(new BaseError()
                {
                    Code = MessageContants.Exception,
                    Message = ex.Message
                });
            }

            return result;
        }

        private static string GetErrorMessage(string statusCode)
        {
            // Switch expression to handle different error status codes and return corresponding messages
            return statusCode switch
            {
                "07" => "Suspicious transaction, potential fraud detected",
                "09" => "Transaction failed due to unregistered InternetBanking account",
                "10" => "Transaction failed due to incorrect account/card authentication",
                "11" => "Transaction timeout",
                "12" => "Account/card is locked",
                "13" => "Incorrect OTP entered",
                "24" => "Transaction cancelled by user",
                "51" => "Insufficient account balance",
                "65" => "Transaction limit exceeded for the day",
                "75" => "Bank under maintenance",
                "79" => "Incorrect payment password entered multiple times",
                _ => "Unknown error occurred" // Default error message for unrecognized status codes
            };
        }

        private static ApiResponse<(PaymentReturnDto, string)> CreateErrorResponse(ApiResponse<(PaymentReturnDto, string)> result,
            PaymentReturnDto resultData, string status, string message)
        {
            resultData.PaymentStatus = status;
            resultData.PaymentMessage = message;
            result.Set(false, MessageContants.Error, (resultData, string.Empty));
            return result;
        }

        private async Task<(int affectedRows, Guid paymentId)> InsertPayment(CreatePaymentRequest request)
        {
            var payment = new Domain.Entities.Payment
            {
                PaymentContent = request.PaymentContent,
                PaymentCurrency = request.PaymentCurrency,
                PaymentRefId = request.PaymentRefId,
                RequiredAmount = request.RequiredAmount,
                PaymentLanguage = request.PaymentLanguage ?? "vi",
                MerchantId = request.MerchantId ?? "Default",
                PaymentDestinationId = request.PaymentDestinationId ?? "Default",
                Signature = request.Signature ?? "Default",
                UserId = request.UserId
            };

            _context.Payments.Add(payment);

            var affectedRows = await _context.SaveChangesAsync();

            return (affectedRows, payment.Id);
        }

        private static int GetRandomNumber(int maxValue)
        {
            byte[] bytes = new byte[4]; // 4 bytes for a 32-bit integer
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(bytes);
            }

            // Convert bytes to a positive integer, and use modulo to limit the range
            int result = Math.Abs(BitConverter.ToInt32(bytes, 0)) % maxValue;
            return result;
        }
        private string GenerateRandomIpAddress()
        {
            Random rnd = new Random();
            int part1 = rnd.Next(1, 256);
            int part2 = rnd.Next(0, 256);
            int part3 = rnd.Next(0, 256);
            int part4 = rnd.Next(0, 256);

            return $"{part1}.{part2}.{part3}.{part4}";
        }

    }
}
