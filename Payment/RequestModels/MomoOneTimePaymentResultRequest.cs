using Microsoft.AspNetCore.Mvc;
using WorkFlex.Payment.Utils.Helpers;

namespace WorkFlex.Payment.RequestModels
{
    [BindProperties]
    public class MomoOneTimePaymentResultRequest
    {
        public string? PartnerCode { get; set; } = string.Empty;
        public string? OrderId { get; set; } = string.Empty;
        public string? RequestId { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string? OrderInfo { get; set; } = string.Empty;
        public string? OrderType { get; set; } = string.Empty;
        public string? TransId { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public int ResultCode { get; set; }
        public string? PayType { get; set; } = string.Empty;
        public long ResponseTime { get; set; }
        public string? ExtraData { get; set; } = string.Empty;
        public string? Signature { get; set; } = string.Empty;

        public bool IsValidSignature(string accessKey, string secretKey)
        {
            var rawHash = "accessKey=" + accessKey +
                   "&amount=" + Amount +
                   "&extraData=" + ExtraData +
                   "&message=" + Message +
                   "&orderId=" + OrderId +
                   "&orderInfo=" + OrderInfo +
                   "&orderType=" + OrderType +
                   "&partnerCode=" + PartnerCode +
                   "&payType=" + PayType +
                   "&requestId=" + RequestId +
                   "&responseTime=" + ResponseTime +
                   "&resultCode=" + ResultCode +
                   "&transId=" + TransId;
            var checkSignature = HashHelper.HmacSHA256(rawHash, secretKey);
            return checkSignature.Equals(Signature);
        }
    }
}
