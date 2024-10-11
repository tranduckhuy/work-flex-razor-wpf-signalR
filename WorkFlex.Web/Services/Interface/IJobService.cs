using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services.Interface
{
    public interface IJobService
    {
        Task<(IEnumerable<JobPostDto> JobDtos, int TotalCount)> GetJobsAsync(JobPostVM filters);

        Task<IEnumerable<JobType>> GetJobTypesAsync();

        Task<JobPostDto> GetJobByIdAsync(Guid id);
    }
}
