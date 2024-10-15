using WorkFlex.Domain.Entities;

namespace WorkFlex.Domain.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        User? GetUserByUsername(string username);

        bool IsEmailExist(string email);

        void AddUser(User user);

        void UpdateUser(User user);

        bool IsAccountLocked(string email);
    }
}