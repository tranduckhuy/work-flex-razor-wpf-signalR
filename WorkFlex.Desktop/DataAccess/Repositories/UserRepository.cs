using WorkFlex.Desktop.DataAccess.DAO;
using WorkFlex.Desktop.DataAccess.Repositories.Interface;
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
