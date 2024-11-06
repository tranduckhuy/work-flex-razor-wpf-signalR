﻿namespace WorkFlex.Payment.Configs.Responses
{
    public class MomoOneTimePaymentCreateLinkResponse
    {
        public string PartnerCode { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public long Amount { get; set; }
        public long ResponseTime { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ResultCode { get; set; } = string.Empty;
        public string PayUrl { get; set; } = string.Empty;
        public string Deeplink { get; set; } = string.Empty;
        public string QrCodeUrl { get; set; } = string.Empty;
    }
}
