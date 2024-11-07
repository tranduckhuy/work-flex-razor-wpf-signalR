using WorkFlex.Payment.Configs.ZaloPay.Request;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;

namespace WorkFlex.Payment.Services
{
    public interface IPaymentService
    {
        Task<ApiResponse<PaymentLinkDtos>> CreatePayment(CreatePaymentRequest request);
        Task<ApiResponse<(PaymentReturnDto, string)>> ProcessMomoPaymentReturn(MomoOneTimePaymentResultRequest request);
        Task<ApiResponse<(PaymentReturnDto, string)>> ProcessZaloPaymentReturn(ZaloOneTimePaymentResultRequest request);
    }
}
