namespace WorkFlex.Services.DTOs
{
    public class UserMessageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string? LastMessage { get; set; } = string.Empty;
        public bool IsLastMessageCurrentUser { get; set; }
        public DateTime? LastMessageTime { get; set; }
    }
}
