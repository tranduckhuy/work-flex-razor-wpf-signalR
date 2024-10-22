using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.SearchCiteria;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IUserService
    {
        Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(int page, UserSearchCriteria? searchCriteria, 
            int roleId, Expression<Func<User, bool>> additionalCriteria = null!);
        Task LockUnlockUser(Guid userId);
        Task DemotePromoteUser(Guid userId);
        Task<UserDto?> GetByIdAsync(Guid id);
        Task UpdateUserAsync(UserDto userDto);
        Task<bool> RequestRecruiterApproval(Guid userId);
        Task<bool> ApproveRecruiterRequest(Guid userId, ISession session, HttpContext httpContext);
        Task<bool> DeclineRecruiterRequest(Guid userId, ISession session, HttpContext httpContext);
    }
}
