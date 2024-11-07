using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkFlex.Payment.Configs.ZaloPay.Request;
using WorkFlex.Payment.Configs.ZaloPay.Response;
using WorkFlex.Payment.Configs.VnPay.Responses;
using WorkFlex.Payment.Dtos;
using WorkFlex.Payment.RequestModels;
using WorkFlex.Payment.ResponseModels;
using WorkFlex.Payment.Services;
using WorkFlex.Payment.Utils.Extensions;

namespace Payment.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("MomoReturn")]
        public async Task<IActionResult> MomoReturn([FromQuery] MomoOneTimePaymentResultRequest request)
        {
            string returnUrl = string.Empty;
            var returnModel = new PaymentReturnDto();
            var result = await _paymentService.ProcessMomoPaymentReturn(request);

            if (result.Success) {
                returnUrl = result.Data.Item2;
                returnModel = result.Data.Item1;
            }

            return Redirect($"{returnUrl}?{returnModel.ToQueryString()}");
        }

        [HttpGet]
        [Route("ZaloReturn")]
        public async Task<IActionResult> ZaloReturn([FromQuery] ZaloOneTimePaymentResultRequest request)
        {
            string returnUrl = string.Empty;
            var returnModel = new PaymentReturnDto();
            var result = await _paymentService.ProcessZaloPaymentReturn(request);

            if (result.Success)
            {
                returnUrl = result.Data.Item2;
                returnModel = result.Data.Item1;
            }

            return Redirect($"{returnUrl}?{returnModel.ToQueryString()}");
        }


        [HttpGet]
        [Route("VnpayReturn")]
        public async Task<IActionResult> VnpayReturn([FromQuery] VnPayOneTimePaymentCreateLinkResponse response)
        {
            string returnUrl = string.Empty;
            var returnModel = new PaymentReturnDto();
            var result = await _paymentService.ProcessVnpayPaymentReturn(response);

            if (result.Success)
            {
                returnUrl = result.Data.Item2;
                returnModel = result.Data.Item1;
            }

            if (returnUrl.EndsWith('/'))
            {
                returnUrl = returnUrl.Remove(returnUrl.Length - 1, 1);
            }
            return Redirect($"{returnUrl}?{returnModel.ToQueryString()}");
        }

    }
}
