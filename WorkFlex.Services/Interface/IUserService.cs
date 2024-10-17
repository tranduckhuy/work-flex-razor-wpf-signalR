using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(Guid id);
    }
}
