using WorkFlex.Domain.Entities;

namespace WorkFlex.Web.Repository.Inteface
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        User? GetUserByUsername(string username);

        bool IsEmailExist(string email);

        void AddUser(User user);
    }
}
