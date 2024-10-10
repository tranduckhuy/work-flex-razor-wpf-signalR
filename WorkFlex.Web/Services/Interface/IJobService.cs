using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services.Interface
{
    public interface IJobService
    {
        Task<(IEnumerable<JobListDto> JobDtos, int TotalCount)> GetJobsAsync(JobListVM filters);

        Task<IEnumerable<JobType>> GetJobTypesAsync();
    }
}
