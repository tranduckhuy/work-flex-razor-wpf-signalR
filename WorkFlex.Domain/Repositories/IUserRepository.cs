using System.Linq.Expressions;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.SearchCiteria;

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

        Task<(ICollection<User>, Pageable<UserSearchCriteria>)> GetUsers(int page, 
            UserSearchCriteria? searchCriteria, int roleId, Expression<Func<User, bool>> additionalCriteria = null!);

        Task LockUnlockUser(Guid userId);

        Task<User> DemotePromoteUser(Guid userId);

        Task<bool> RequestRecruiterApproval(Guid userId);
        Task<User> DeclineRecruiterRequest(Guid userId);

    }
}