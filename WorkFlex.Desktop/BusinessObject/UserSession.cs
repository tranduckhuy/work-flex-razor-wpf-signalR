using WorkFlex.Desktop.BusinessObject.DTO;

namespace WorkFlex.Desktop.BusinessObject
{
    public class UserSession
	{
		private static UserSession _instance = null!;
		private static readonly object _lock = new object();
		public UserDTO CurrentUser { get; private set; } = null!;
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

		public void SetUser(UserDTO user)
		{
			CurrentUser = user;
		}
		public UserDTO GetUser()
		{
			return CurrentUser;
		}
		public void Reset()
		{
			CurrentUser = null!;
		}
	}
}
