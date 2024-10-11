using WorkFlex.Domain.Entities;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Repository.Interface
{
    public interface IJobRepository
    {
        Task<(IEnumerable<JobPost> Jobs, int TotalCount)> GetJobsAsync(JobPostVM filters);
        
        Task<IEnumerable<JobType>> GetJobTypesAsync();

        Task<JobPost> GetJobByIdAsync(Guid id);
    }
}
