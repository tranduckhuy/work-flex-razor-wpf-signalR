namespace WorkFlex.Web.ViewModels
{
    public class ProfileVM
    {
        public Guid Id { get; set; }

        // Profile form properties
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = null!;

        public string Website { get; set; } = string.Empty;

        public string Headline { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string Apartment { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string Ward { get; set; } = string.Empty;

        public string AboutDescription { get; set; } = string.Empty;

        // Change password form properties
        public string OldPassword { get; set; } = null!;

        public string NewPassword { get; set; } = null!;

        public string ReEnterPassword { get; set; } = null!;
    }
}
