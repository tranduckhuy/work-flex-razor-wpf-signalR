using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IJobService
    {
        Task<(IEnumerable<JobPostDto> JobDtos, int TotalCount)> GetJobsAsync(JobFilter filters);

        Task<IEnumerable<JobType>> GetJobTypesAsync();

        Task<JobPostDto?> GetJobByIdAsync(Guid id);
    }
}
