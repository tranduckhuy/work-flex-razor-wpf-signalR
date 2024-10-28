namespace WorkFlex.Web.ViewModels
{
    public class UpdateImageProfileVM
    {
        public Guid Id { get; set; }

        public string AvatarUrl { get; set; } = string.Empty;

        public string BackgroundUrl {  get; set; } = string.Empty;
    }
}
