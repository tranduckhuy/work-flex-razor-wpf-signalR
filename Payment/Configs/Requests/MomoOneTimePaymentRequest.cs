using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WorkFlex.Payment.Configs.Responses;
using WorkFlex.Payment.Utils.Helpers;
using System.Text;

namespace WorkFlex.Payment.Configs.Requests
{
    public class MomoOneTimePaymentRequest
    {
        public string PartnerCode { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string OrderId { get; set; } = string.Empty;
        public string OrderInfo { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;
        public string IpnUrl { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty;
        public string ExtraData { get; set; } = string.Empty;
        public string Lang { get; set; } = "vi";
        public string Signature { get; set; } = string.Empty;

        public MomoOneTimePaymentRequest()
        {
        }

        public void MakeSignature(string accessKey, string secretKey)
        {
            var rawHash = "accessKey=" + accessKey +
                "&amount=" + Amount +
                "&extraData=" + ExtraData +
                "&ipnUrl=" + IpnUrl +
                "&orderId=" + OrderId +
                "&orderInfo=" + OrderInfo +
                "&partnerCode=" + PartnerCode +
                "&redirectUrl=" + RedirectUrl +
                "&requestId=" + RequestId +
                "&requestType=" + RequestType;
            Signature = HashHelper.HmacSHA256(rawHash, secretKey);
        }

        public (bool, string) GetLink(string paymentUrl)
        {
            using HttpClient client = new HttpClient();

            var requestData = JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            });

            var requestContent = new StringContent(requestData, Encoding.UTF8, "application/json");

            var createPaymentLinkRes = client.PostAsync(paymentUrl, requestContent)
                .Result;

            if (createPaymentLinkRes.IsSuccessStatusCode)
            {
                var responseContent = createPaymentLinkRes.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert
                    .DeserializeObject<MomoOneTimePaymentCreateLinkResponse>(responseContent);

                if (responseData == null)
                {
                    return (false, "Response data is null");
                }

                if (responseData.ResultCode == "0")
                {
                    return (true, responseData.PayUrl);
                }
                else
                {
                    return (false, responseData.Message);
                }

            }
            else
            {
                return (false, createPaymentLinkRes.ReasonPhrase ?? "An error occurred when getting payment link");
            }
        }
    }
}
