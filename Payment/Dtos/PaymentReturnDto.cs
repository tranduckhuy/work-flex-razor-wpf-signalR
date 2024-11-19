namespace WorkFlex.Payment.Dtos
{
    public class PaymentReturnDto
    {
        public string? PaymentId { get; set; }
        /// <summary>
        /// 00: Success
        /// 99: Unknown
        /// 10: Error
        /// </summary>
        public string PaymentStatus { get; set; } = string.Empty;
        public string PaymentMessage { get; set; } = string.Empty;
        /// <summary>
        /// Format: yyyyMMddHHmmss
        /// </summary>
        public string PaymentDate { get; set; } = string.Empty;
        public string PaymentRefId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Signature { get; set; } = string.Empty;
    }
}
