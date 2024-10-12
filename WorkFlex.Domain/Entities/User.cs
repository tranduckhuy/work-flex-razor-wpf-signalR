
using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(40)]
        public string? Username { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Avatar { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Phone { get; set; } = string.Empty;

        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Location { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int RoleId { get; set; }
        public bool IsLock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Profile Profile { get; set; } = null!;
        public virtual ICollection<JobPost> JobPosts { get; set; } = [];
        public virtual ICollection<Conversation> ConversationsAsUserOne { get; set; } = [];
        public virtual ICollection<Conversation> ConversationsAsUserTwo { get; set; } = [];
        public virtual ICollection<ConversationReply> ConversationReplies { get; set; } = [];
        public virtual ICollection<JobApplication> JobApplications { get; set; } = [];
    }
}
