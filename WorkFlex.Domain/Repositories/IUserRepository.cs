using System.Linq.Expressions;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByIdAsync(Guid id);

        Task<User> DemotePromoteUser(Guid userId);

        Task<User> DeclineRecruiterRequest(Guid userId);

        Task<bool> IsEmailExistAsync(string email);

        Task<bool> IsAccountLockedAsync(string email);

        Task<bool> RequestRecruiterApproval(Guid userId);

        Task AddUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task LockUnlockUser(Guid userId);

        Task<(ICollection<User>, Pageable<SearchCriteria>)> GetUsers(int page, 
            SearchCriteria? searchCriteria, int roleId, Expression<Func<User, bool>> additionalCriteria = null!);
    }
}