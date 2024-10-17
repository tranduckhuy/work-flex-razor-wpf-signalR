using WorkFlex.Domain.Entities;

namespace WorkFlex.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByIdAsync(Guid id);

        Task<bool> IsEmailExistAsync(string email);

        Task<bool> IsAccountLockedAsync(string email);

        Task AddUserAsync(User user);

        Task UpdateUserAsync(User user);
    }
}