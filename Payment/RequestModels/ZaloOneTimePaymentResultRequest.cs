namespace WorkFlex.Payment.RequestModels
{
    public class ZaloOneTimePaymentResultRequest
    {
        public long Amount { get; set; } = 0;
        public int AppId { get; set; } = 2554;
        public string AppTransId { get; set; } = string.Empty;
        public string CheckSum { get; set; } = string.Empty;
        public long DiscountAmount { get; set; } = 0;
        public int PmCid { get; set; } = 0;
        public int Status { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
    }
}
