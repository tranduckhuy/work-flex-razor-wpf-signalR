using AutoMapper;
using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Repository.Inteface;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services
{
    public class JobService : IJobService
    {
        private readonly ILogger<JobService> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(ILogger<JobService> logger, IMapper mapper, IJobRepository jobRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _jobRepository = jobRepository;
        }

        public async Task<(IEnumerable<JobListDto> JobDtos, int TotalCount)> GetJobsAsync(JobListVM filters)
        {
            _logger.LogInformation("[GetJobsAsync]: Service - Start getting job list data");
            try
            {
                var (jobs, totalCount) = await _jobRepository.GetJobsAsync(filters);
                var jobDtos = _mapper.Map<IEnumerable<JobListDto>>(jobs);

                foreach (var jobDto in jobDtos)
                {
                    if (!string.IsNullOrEmpty(jobDto.JobLocation))
                    {
                        var jobLocationParts = jobDto.JobLocation.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        jobDto.JobLocation = jobLocationParts.LastOrDefault()!.Trim();
                    }

                    var timeDifference = DateTime.UtcNow - jobDto.CreatedAt;
                    if (timeDifference.TotalDays > 5)
                    {
                        jobDto.DisplayCreatedAt = jobDto.CreatedAt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        int daysAgo = (int)timeDifference.TotalDays;
                        if (daysAgo > 0)
                        {
                            jobDto.DisplayCreatedAt = $"{daysAgo} Days Ago";
                        }
                        else
                        {
                            jobDto.DisplayCreatedAt = $"Today";
                        }

                    }
                }
                _logger.LogInformation("[GetJobsAsync]: Service - End getting job list data with data: List-data: {jobDtos}, Total-count: {totalCount}", jobDtos, totalCount);
                return (jobDtos, totalCount);
            } catch (Exception ex)
            {
                _logger.LogError("[GetJobsAsync]: Service - End getting job list data with error: {ex}", ex);
                return ([], 0);
            }
        }

        public async Task<IEnumerable<JobType>> GetJobTypesAsync()
        {
            return await _jobRepository.GetJobTypesAsync();
        }
    }
}
