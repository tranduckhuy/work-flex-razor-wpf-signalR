using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Configs.Momo.Requests;
using WorkFlex.Payment.Configs.VnPay.Configs;
using WorkFlex.Payment.Configs.VnPay.Requests;
using WorkFlex.Payment.Configs.VnPay.Responses;
using WorkFlex.Payment.Configs.ZaloPay.Config;
using WorkFlex.Payment.Configs.ZaloPay.Request;
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

                            var zaloPayment = new ZaloOneTimePaymentRequest(_zaloConfig.AppId, _zaloConfig.AppUser, 
                                DateTime.Now.ToString("yyMMdd") + "_" + randomNumber, DateTime.Now.GetTimeStamp(),
                                (long)request.RequiredAmount!, request.PaymentContent ?? string.Empty, "zalopayapp");
                            zaloPayment.MakeSignature(_zaloConfig.Key1);

                            var (successZalo, messageZalo) = zaloPayment.GetLink(_zaloConfig.PaymentUrl);
                            if (successZalo)
                            {
                                paymentUrl = messageZalo;
                            }
                            else
                            {
                                result.Set(false, messageZalo);
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
            string redirectWebUrl = _momoConfig.RedirectWebUrl;
            var result = new ApiResponse<(PaymentReturnDto, string)>();
            result.Success = false;

            try
            {
                var resultData = new PaymentReturnDto();
                var isValidSignature = request.IsValidSignature(_momoConfig.AccessKey, _momoConfig.SecretKey);

                Guid paymentId = Guid.Empty;

                if (isValidSignature && Guid.TryParse(request.OrderId, out paymentId))
                {
                    var payment = _context.Payments.FirstOrDefault(p => p.Id == paymentId);

                    if (payment != null)
                    {

                        if (request.ResultCode == 0)
                        {
                            payment.IsPaid = request.ResultCode == 0;
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
                }
                else
                {
                    resultData.PaymentStatus = "11";
                    resultData.PaymentMessage = "Can't find payment at payment service or Invalid signature in response";
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

        public async Task<ApiResponse<(PaymentReturnDto, string)>> ProcessVnpayPaymentReturn(VnPayOneTimePaymentCreateLinkResponse response)
        {
            string redirectWebUrl = _vnPayConfig.RedirectWebUrl;
            var result = new ApiResponse<(PaymentReturnDto, string)>();
            result.Success = false;

            try
            {
                var resultData = new PaymentReturnDto();
                var isValidSignature = response.isValidSignature(_vnPayConfig.HashSecret);

                Guid paymentId = Guid.Empty;

                if (isValidSignature && Guid.TryParse(response.vnp_TxnRef, out paymentId))
                {
                    var payment = _context.Payments.FirstOrDefault(p => p.Id == paymentId);

                    if (payment != null)
                    {
                        switch (response.vnp_ResponseCode)
                        {
                            case "00":
                                if (response.vnp_TransactionStatus == "00")
                                {
                                    payment.IsPaid = true;
                                    await _context.SaveChangesAsync();

                                    resultData.PaymentStatus = "00"; 
                                    resultData.PaymentId = payment.Id.ToString();
                                    resultData.Signature = Guid.NewGuid().ToString();
                                    result.Set(true, MessageContants.OK, (resultData, redirectWebUrl));
                                }
                                else
                                {
                                    resultData.PaymentStatus = response.vnp_TransactionStatus;
                                    resultData.PaymentMessage = "Transaction failed at VNPAY gateway";
                                }
                                break;

                            case "07":
                                resultData.PaymentStatus = "07";
                                resultData.PaymentMessage = "Suspicious transaction, potential fraud detected";
                                break;

                            case "09":
                                resultData.PaymentStatus = "09";
                                resultData.PaymentMessage = "Transaction failed due to unregistered InternetBanking account";
                                break;

                            case "10":
                                resultData.PaymentStatus = "10";
                                resultData.PaymentMessage = "Transaction failed due to incorrect account/card authentication";
                                break;

                            case "11":
                                resultData.PaymentStatus = "11";
                                resultData.PaymentMessage = "Transaction timeout";
                                break;

                            case "12":
                                resultData.PaymentStatus = "12";
                                resultData.PaymentMessage = "Account/card is locked";
                                break;

                            case "13":
                                resultData.PaymentStatus = "13";
                                resultData.PaymentMessage = "Incorrect OTP entered";
                                break;

                            case "24":
                                resultData.PaymentStatus = "24";
                                resultData.PaymentMessage = "Transaction cancelled by user";
                                break;

                            case "51":
                                resultData.PaymentStatus = "51";
                                resultData.PaymentMessage = "Insufficient account balance";
                                break;

                            case "65":
                                resultData.PaymentStatus = "65";
                                resultData.PaymentMessage = "Transaction limit exceeded for the day";
                                break;

                            case "75":
                                resultData.PaymentStatus = "75";
                                resultData.PaymentMessage = "Bank under maintenance";
                                break;

                            case "79":
                                resultData.PaymentStatus = "79";
                                resultData.PaymentMessage = "Incorrect payment password entered multiple times";
                                break;

                            case "99":
                            default:
                                resultData.PaymentStatus = "99";
                                resultData.PaymentMessage = "Unknown error occurred";
                                break;
                        }

                        if (!result.Success)
                        {
                            result.Set(false, resultData.PaymentMessage, (resultData, redirectWebUrl));
                        }
                    }
                    else
                    {
                        resultData.PaymentStatus = "11";
                        resultData.PaymentMessage = "Payment not found in service or invalid signature";
                    }
                }
                else
                {
                    resultData.PaymentStatus = "11";
                    resultData.PaymentMessage = "Payment not found in service or invalid signature";
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
