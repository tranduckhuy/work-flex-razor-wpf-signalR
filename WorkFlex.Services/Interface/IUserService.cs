using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Services.DTOs;
using static WorkFlex.Infrastructure.Constants.AppConstants;

namespace WorkFlex.Services.Interface
{
    public interface IUserService
    {
        Task LockUnlockUser(Guid userId);

        Task DemotePromoteUser(Guid userId);

        Task UpdateUserAsync(UserDto userDto);

        Task<bool> RequestRecruiterApproval(Guid userId);

        Task<bool> ApproveRecruiterRequest(Guid userId, ISession session, HttpContext httpContext);

        Task<bool> DeclineRecruiterRequest(Guid userId, ISession session, HttpContext httpContext);

        Task<bool> UpdateUserProfileAsync(ProfileDto profileDto);

        Task<ProfileResult> ChangePasswordAsync(ProfileDto profileDto);

        Task<UserDto?> GetByIdAsync(Guid id);

        Task<(ICollection<UserDto>, Pageable<SearchCriteria>)> GetUsers(int page, SearchCriteria? searchCriteria,
            int roleId, Expression<Func<User, bool>> additionalCriteria = null!);
    }
}
