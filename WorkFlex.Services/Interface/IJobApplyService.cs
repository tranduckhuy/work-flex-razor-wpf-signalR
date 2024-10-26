using WorkFlex.Domain;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IJobApplyService
    {
        Task<(ICollection<JobApplicantDto>, Pageable<SearchCriteria>)> GetJobApplicationsAsync(Guid jobPostId, 
            SearchCriteria? searchCriteria, int page);
        Task<bool> IsUserPostOwnerAsync(Guid userId, Guid jobPostId);
    }
}
