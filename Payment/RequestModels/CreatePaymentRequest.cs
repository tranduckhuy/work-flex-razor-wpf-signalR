namespace WorkFlex.Payment.RequestModels
{
    public class CreatePaymentRequest
    {
        public string PaymentContent { get; set; } = "Thanh Toan Goi Thanh Vien";
        public string PaymentCurrency { get; set; } = "VND";
        public string PaymentRefId { get; set; } = "PaymentRefId";
        public decimal RequiredAmount { get; set; } = 101206.35m;
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public DateTime? ExpireDate { get; set; } = DateTime.Now.AddMinutes(15);
        public string? PaymentLanguage { get; set; } = "vi";
        public string? MerchantId { get; set; } =  "MER0001";
        public string? PaymentDestinationId { get; set; } = string.Empty;
        public string? Signature { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
