using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class ConversationReply
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Reply { get; set; } = string.Empty;

        [Required]
        public Guid UserId { get; set; }

        public DateTime Time { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid ConversationId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Conversation Conversation { get; set; } = null!;
    }
}