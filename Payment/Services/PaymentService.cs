using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using WorkFlex.Domain;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Configs.Momo.Requests;
using WorkFlex.Payment.Configs.VnPay.Configs;
using WorkFlex.Payment.Configs.VnPay.Requests;
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
            var result = new ApiResponse<(PaymentReturnDto, string)>() { Success = false };
            var resultData = new PaymentReturnDto();

            try
            {
                if (!request.IsValidSignature(_momoConfig.AccessKey, _momoConfig.SecretKey) ||
                    !Guid.TryParse(request.OrderId, out Guid paymentId))
                {
                    return CreateErrorResponse(result, resultData, "11", "Can't find payment at payment service or Invalid signature in response");
                }

                var payment = await _context.Payments.FindAsync(paymentId);
                if (payment == null)
                {
                    return CreateErrorResponse(result, resultData, "11", "Payment not found");
                }

                if (request.ResultCode != 0)
                {
                    return CreateErrorResponse(result, resultData, "10", "Payment process failed");
                }

                payment.IsPaid = true;
                await _context.SaveChangesAsync();

                var user = await _context.Users.FindAsync(payment.UserId);
                if (user != null)
                {
                    user.SubscriptionType = SubscriptionType.Premium;
                    await _context.SaveChangesAsync();
                }

                resultData.PaymentStatus = "00";
                resultData.PaymentId = payment.Id.ToString();
                resultData.Signature = Guid.NewGuid().ToString();
                result.Set(true, MessageContants.OK, (resultData, redirectWebUrl));
            }
            catch (Exception ex)
            {
                result.Set(false, MessageContants.Error);
                result.Errors.Add(new BaseError
                {
                    Code = MessageContants.Exception,
                    Message = ex.Message
                });
            }

            return result;
        }

        private ApiResponse<(PaymentReturnDto, string)> CreateErrorResponse(ApiResponse<(PaymentReturnDto, string)> result,
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
