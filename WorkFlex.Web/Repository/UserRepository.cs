using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.Repository.Inteface;

namespace WorkFlex.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User? GetUserByEmail(string email)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserByUsername(string username)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Username == username);
        }
    }
}
