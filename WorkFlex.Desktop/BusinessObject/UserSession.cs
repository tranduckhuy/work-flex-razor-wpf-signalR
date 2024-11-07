using WorkFlex.Services.DTOs;

namespace WorkFlex.Desktop.BusinessObject
{
    public class UserSession
	{
		private static UserSession _instance = null!;
		private static readonly object _lock = new object();
		public UserDto CurrentUser { get; private set; } = null!;
		public static UserSession Instance
		{
			get
			{
				lock (_lock)
				{
					return _instance ??= new UserSession();
				}
			}
		}

		public void SetUser(UserDto user)
		{
			CurrentUser = user;
		}

		public UserDto GetUser()
		{
			return CurrentUser;
		}

		public void Reset()
		{
			CurrentUser = null!;
		}
	}
}
