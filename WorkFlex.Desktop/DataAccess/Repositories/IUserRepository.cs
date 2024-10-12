using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.DataAccess.Repositories
{
	public interface IUserRepository
	{
		Task<User?> GetByEmailAndPasswordAsync(string email, string password);
	}
}
