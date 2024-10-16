using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsAccountLockedAsync(string email)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return user.IsLock;
        }

        public async Task AddUserAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
