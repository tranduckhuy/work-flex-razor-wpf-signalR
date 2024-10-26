using WorkFlex.Domain.Entities;

namespace WorkFlex.Domain.Repositories
{
    public interface IJobApplyRepository
    {
        Task<(ICollection<JobApplication>, Pageable<SearchCriteria>)> GetJobApplicationsAsync(Guid jobPostId, 
            SearchCriteria? searchCriteria, int page);
        Task<bool> IsUserPostOwnerAsync(Guid userId, Guid jobPostId);
    }
}
