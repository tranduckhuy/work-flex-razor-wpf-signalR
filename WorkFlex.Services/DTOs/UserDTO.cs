using WorkFlex.Domain.Entities;

namespace WorkFlex.Services.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public int RoleId { get; set; }

        public bool IsLock { get; set; }

        public Role Role { get; set; } = null!;

        public Profile Profile { get; set; } = null!;

        public ICollection<JobPost> JobPosts { get; set; } = [];

        public ICollection<Conversation> ConversationsAsUserOne { get; set; } = [];

        public ICollection<Conversation> ConversationsAsUserTwo { get; set; } = [];

        public ICollection<ConversationReply> ConversationReplies { get; set; } = [];

        public ICollection<JobApplication> JobApplications { get; set; } = [];
    }
}
