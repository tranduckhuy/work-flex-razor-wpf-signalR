namespace WorkFlex.Services.DTOs
{
    public class ProfileDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string? Website { get; set; }
        public string? Headline { get; set; }
        public string? Street { get; set; }
        public string? Apartment { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Location { get; set; }
        public string? AboutDescription { get; set; }

        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ReEnterPassword { get; set; } = null!;
    }
}
