using Newtonsoft.Json;
using WorkFlex.Payment.Configs.ZaloPay.Response;
using WorkFlex.Payment.Utils.Helpers;

namespace WorkFlex.Payment.Configs.ZaloPay.Request
{
    public class ZaloOneTimePaymentRequest
    {
        public int AppId { get; set; }
        public string AppUser { get; set; } = string.Empty;
        public string AppTransId { get; set; } = string.Empty;
        public long AppTime { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BankCode { get; set; } = string.Empty;
        public string Mac { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;
        public int ReturnCode { get; set; }
        public string IpnUrl { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty;

        public ZaloOneTimePaymentRequest()
        {
        }

        public ZaloOneTimePaymentRequest(int appId, string appUser, string appTransId, 
                                         long appTime, long amount, string description, 
                                         string bankCode, string redirectUrl)
        {
            AppId = appId;
            AppUser = appUser;
            AppTransId = appTransId;
            AppTime = appTime;
            Amount = amount;
            Description = description;
            BankCode = bankCode;
            RedirectUrl = redirectUrl;
        }

        public void MakeSignature(string key)
        {
            var dataObject = new
            {
                redirecturl = RedirectUrl,
                preferred_payment_method = Array.Empty<string>(),
            };
            var rawHash = AppId.ToString() + "|"
              + AppTransId + "|"
              + AppUser + "|"
              + Amount.ToString() + "|"
              + AppTime.ToString() + "|"
              + JsonConvert.SerializeObject(dataObject) + "|"  
              + JsonConvert.SerializeObject(Array.Empty<object>()).Trim(); 

            Mac = HashHelper.HmacSHA256(rawHash, key);
        }

        public Dictionary<string, string> GetContent()
        {
            var embedDataObject = new
            {
                redirecturl = RedirectUrl,
                preferred_payment_method = Array.Empty<string>()
            };
            Dictionary<string, string> keyValuePairs = new()
            {
                { "app_id", AppId.ToString() },
                { "app_user", AppUser },
                { "app_trans_id", AppTransId },
                { "app_time", AppTime.ToString() },
                { "amount", Amount.ToString() },
                { "description", Description },
                { "bank_code", "zalopayapp" },
                { "embed_data", JsonConvert.SerializeObject(embedDataObject) },
                { "item", "[]" },
                { "mac", Mac }
            };

            return keyValuePairs;
        }

        public (bool, string) GetLink(string paymentUrl)
        {
            using HttpClient client = new();

            var content = new FormUrlEncodedContent(GetContent());
            var createPaymentLinkRes = client.PostAsync(paymentUrl, content).Result;

            if (createPaymentLinkRes.IsSuccessStatusCode)
            {
                var responseContent = createPaymentLinkRes.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<ZaloOneTimePaymentResponse>(responseContent);

                if (responseData == null)
                {
                    return (false, "Response data is null");
                }

                ReturnCode = responseData.ReturnCode;
                if (responseData.ReturnCode == 1)
                {
                    return (true, responseData.OrderUrl);
                }
                else
                {
                    return (false, responseData.ReturnMessage);
                }

            }
            else
            {
                return (false, createPaymentLinkRes.ReasonPhrase ?? "An error occurred when getting payment link");
            }
        }
    }
}
