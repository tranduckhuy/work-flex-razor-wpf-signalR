using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;

namespace WorkFlex.Domain.Repositories
{
    public interface IJobRepository
    {
        Task<(IEnumerable<JobPost> Jobs, int TotalCount)> GetJobsAsync(JobFilter filters);

        Task<IEnumerable<JobType>> GetJobTypesAsync();

        Task<JobPost> GetJobByIdAsync(Guid id);
    }
}
