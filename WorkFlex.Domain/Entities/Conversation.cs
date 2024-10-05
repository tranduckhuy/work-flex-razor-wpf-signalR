using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class Conversation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserOne { get; set; }

        [Required]
        public Guid UserTwo { get; set; }

        public DateTime Time { get; set; } = DateTime.UtcNow;

        public virtual User UserOneNavigation { get; set; } = null!;
        public virtual User UserTwoNavigation { get; set; } = null!;
        public virtual ICollection<ConversationReply> ConversationReplies { get; set; } = [];
    }
}