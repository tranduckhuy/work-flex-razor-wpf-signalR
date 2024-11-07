namespace WorkFlex.Services.DTOs
{
    public class ConversationDto
    {
        public Guid Id { get; set; }
        public Guid UserOne { get; set; }
        public Guid UserTwo { get; set; }
        public DateTime Time { get; set; }
    }
}
