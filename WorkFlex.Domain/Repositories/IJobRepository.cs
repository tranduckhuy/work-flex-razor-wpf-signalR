using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;

namespace WorkFlex.Domain.Repositories
{
    public interface IJobRepository
    {
        Task<(IEnumerable<JobPost> Jobs, int TotalCount, int TotalPages)> GetJobsAsync(JobFilter filters);

		Task<(IEnumerable<JobPost> JobPosts, Pageable<SearchCriteria> pageable)> GetJobsByUserIdAsync(int page,
                    Guid userId, SearchCriteria searchCriteria);

		Task<IEnumerable<JobType>> GetJobTypesAsync();

		Task<IEnumerable<Industry>> GetIndustriesAsync();

		Task<JobPost> GetJobByIdAsync(Guid id);

		Task AddJobPostAsync(JobPost jobPost);

		Task UpdateJobPostAsync(JobPost jobPost);
	}
}
