using Microsoft.Extensions.Options;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Configs.Requests;
using WorkFlex.Payment.Configs.ZaloPay.Config;
using WorkFlex.Payment.Configs.ZaloPay.Request;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;
using WorkFlex.Payment.Utils.Constants;
using WorkFlex.Payment.Utils.Helpers;

namespace WorkFlex.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly MomoConfig _momoConfig;
        private readonly ZaloPayConfig _zaloConfig;
        private readonly AppDbContext _context;

        public PaymentService(IOptions<MomoConfig> momoConfig, IOptions<ZaloPayConfig> zaloConfig, AppDbContext context)
        {
            _momoConfig = momoConfig.Value;
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
                                RedirectUrl = _momoConfig.ReturnUrl,
                                IpnUrl = _momoConfig.IpnUrl,
                                RequestType = RequestType.CaptureWallet
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
                            }

                            break;
                        case nameof(PaymentMethod.ZALOPAY):
                            var random = new Random();
                            int randomNumber = random.Next(1000000);

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
    }
}
