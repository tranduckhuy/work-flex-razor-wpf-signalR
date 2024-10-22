using WorkFlex.Domain.Entities;

namespace WorkFlex.Web.ViewModels
{
	public class UserVM
	{
		public Guid Id { get; set; }

		public string Username { get; set; } = string.Empty;

		public string Avatar { get; set; } = string.Empty;

		public string FirstName { get; set; } = string.Empty;

		public string FullName => $"{FirstName} {LastName}";

		public string LastName { get; set; } = string.Empty;

		public string Phone { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;

		public DateTime DateOfBirth { get; set; }

		public int RoleId { get; set; }

		public bool IsLock { get; set; }

        public bool IsRecruiterRequestPending { get; set; }

        public Role Role { get; set; } = null!;
	}
}
