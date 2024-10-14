using WorkFlex.Web.DTOs;

namespace WorkFlex.Web.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    }
}
