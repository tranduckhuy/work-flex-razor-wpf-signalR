namespace WorkFlex.Payment.RequestModels
{
    public class ZaloOneTimePaymentResultRequest
    {
        public long Amount { get; set; }
        public int AppId { get; set; }
        public string AppTransId { get; set; } = string.Empty;
        public string CheckSum { get; set; } = string.Empty;
        public long DiscountAmount { get; set; }
        public int PmCid { get; set; }
        public int Status { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
