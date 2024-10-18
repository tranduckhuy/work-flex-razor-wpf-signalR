using WorkFlex.Domain;
using WorkFlex.Domain.SearchCiteria;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IUserService
    {
        Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(int page, UserSearchCriteria? searchCiteria, int roleId);
        Task LockUnlockUser(Guid userId);
        Task DemotePromoteUser(Guid userId);
        Task<UserDto?> GetByIdAsync(Guid id);
    }
}
