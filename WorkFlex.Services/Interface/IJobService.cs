using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IJobService
    {
        Task<bool> AddJobPostAsync(JobPostDto jobPostDto);

        Task<bool> UpdateJobPostAsync(JobPostDto jobPostDto);

        Task<bool> DeleteJobPostAsync(Guid id);

        Task<(IEnumerable<JobPostDto> JobDtos, int TotalCount, int TotalPages)> GetJobsAsync(JobFilter filters);

        Task<IEnumerable<JobType>> GetJobTypesAsync();

        Task<IEnumerable<Industry>> GetIndustriesAsync();

        Task<JobPostDto?> GetJobByIdAsync(Guid id);
    }
}
