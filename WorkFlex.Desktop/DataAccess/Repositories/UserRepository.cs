using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlex.Desktop.DataAccess.DAO;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		public async Task<User?> GetByEmailAsync(string email)
		{
			return await UserDAO.Instance.GetByEmailAsync(email);
		}
	}
}
