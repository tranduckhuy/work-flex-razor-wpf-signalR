using Newtonsoft.Json;

namespace WorkFlex.Payment.Configs.ZaloPay.Response
{
    public class ZaloOneTimePaymentResponse
    {
        [JsonProperty("return_code")]
        public int ReturnCode { get; set; }

        [JsonProperty("return_message")]
        public string ReturnMessage { get; set; } = string.Empty;

        [JsonProperty("order_url")]
        public string OrderUrl { get; set; } = string.Empty;
    }
}
