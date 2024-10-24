namespace WorkFlex.Services.DTOs
{
    public class ConversationReplyDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Reply { get; set; } = string.Empty;
        public DateTime Time { get; set; }
    }
}
