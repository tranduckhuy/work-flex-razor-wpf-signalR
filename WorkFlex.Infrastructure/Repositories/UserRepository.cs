using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Infrastructure.Repositories
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

        public bool IsEmailExist(string email)
        {
            return _appDbContext.Users.Any(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _appDbContext.Update(user);
            _appDbContext.SaveChanges();
        }

        public bool IsAccountLocked(string email)
        {
            var user = _appDbContext.Users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return user.IsLock;
        }
    }
}
