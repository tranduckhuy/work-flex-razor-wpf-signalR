using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.DTOs;
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

        public User? getUserByEmail(string email)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? getUserByUsername(string username)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Username == username);
        }

        public bool isEmailExist(string email)
        {
            return _appDbContext.Users.Any(u => u.Email == email);
        }

        public void addUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        //Get All Users
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _appDbContext.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Avatar = u.Avatar,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Phone = u.Phone,
                    Email = u.Email,
                    Location = u.Location,
                    DateOfBirth = u.DateOfBirth,
                    RoleId = u.RoleId,
                    IsLock = u.IsLock
                })
                .ToListAsync();
        }
    }
}
