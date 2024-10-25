namespace WorkFlex.Web.ViewModels
{
    public class UserMessageVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string? LastMessage { get; set; }
        public bool IsLastMessageCurrentUser { get; set; }
    }
}
