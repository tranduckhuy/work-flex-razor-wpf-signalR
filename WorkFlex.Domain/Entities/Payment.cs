using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(255)]
        public string PaymentContent { get; set; } = string.Empty;

        [StringLength(10)]
        public string PaymentCurrency { get; set; } = string.Empty;

        [StringLength(50)]
        public string PaymentRefId { get; set; } = string.Empty;

        public decimal RequiredAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(15);

        [Required]
        public string PaymentLanguage { get; set; } = string.Empty;

        [StringLength(50)]
        public string MerchantId { get; set; } = string.Empty;

        [StringLength(50)]
        public string PaymentDestinationId { get; set; } = string.Empty;

        [StringLength(100)]
        public string Signature { get; set; } = string.Empty;
        public bool IsPaid { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
