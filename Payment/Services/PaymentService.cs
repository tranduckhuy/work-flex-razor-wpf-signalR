using Microsoft.Extensions.Options;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Configs.Requests;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;
using WorkFlex.Payment.Utils.Constants;

namespace WorkFlex.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly MomoConfig _momoConfig;
        private readonly AppDbContext _context;

        public PaymentService(IOptions<MomoConfig> options, AppDbContext context)
        {
            _momoConfig = options.Value;
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
