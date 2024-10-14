using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;

namespace WorkFlex.Web.Repository.Inteface
{
    public interface IUserRepository
    {
        User? getUserByEmail(string email);

        User? getUserByUsername(string username);

        bool isEmailExist(string email);

        void addUser(User user);

        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    }
}
