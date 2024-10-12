using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Desktop.DataAccess.DAO
{
	public class UserDAO
	{
		private static UserDAO _instance = null!;
		private static readonly object _lock = new object();

		public static UserDAO Instance
		{
			get
			{
				lock (_lock)
				{
					return _instance ??= new UserDAO();
				}
			}
		}
        public UserDAO()
        {
        }
		public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
		{
			using var _context = new AppDbContext();
			return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
		}

	}
}
