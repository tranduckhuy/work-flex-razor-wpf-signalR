using WorkFlex.Domain.Entities;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Repository.Interface
{
    public interface IJobRepository
    {
        Task<(IEnumerable<JobPost> Jobs, int TotalCount)> GetJobsAsync(JobListVM filters);
        
        Task<IEnumerable<JobType>> GetJobTypesAsync();
    }
}
