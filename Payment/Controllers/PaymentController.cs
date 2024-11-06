using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;
using WorkFlex.Payment.Services;
using System.Net;

namespace Payment.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly MomoConfig _momoConfig;

        public PaymentController(IPaymentService paymentService, IOptions<MomoConfig> momoConfig)
        {
            _paymentService = paymentService;
            _momoConfig = momoConfig.Value;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        ///     POST /api/Payment
        ///     {
        ///          "paymentContent": "Thanh Toan Goi Thanh Vien 0001",
        ///          "paymentCurrency": "VND",
        ///          "paymentRefId": "ORD1234",
        ///          "requiredAmount": 10000,
        ///          "paymentLanguage": "vi",
        ///          "merchantId": "MER0001",
        ///          "paymentDestinationId": "MOMO",
        ///          "signature": "12345ABCD",
        ///          "userId": "A5FE7542-F00C-4E13-A82C-8153BFD405A8"
        ///     }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<PaymentLinkDtos>), 200)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePayment([FromBody]CreatePaymentRequest request)
        {
            var response = await _paymentService.CreatePayment(request);
            return Ok(response);
        }
    }
}
