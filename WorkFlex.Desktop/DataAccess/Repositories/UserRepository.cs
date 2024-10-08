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
		public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
		{
			return await UserDAO.Instance.GetByEmailAndPasswordAsync(email, password); 
		}
	}
}
