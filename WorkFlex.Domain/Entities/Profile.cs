using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class Profile
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Headline { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Website { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}