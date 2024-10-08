namespace WorkFlex.Web.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username {  get; set; } = String.Empty;

        public string Avatar {  get; set; } = String.Empty;

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Location { get; set; } = String.Empty;

        public DateTime DateOfBirth { get; set; }

        public int RoleId { get; set; }

        public bool IsLock { get; set; }
    }
}
