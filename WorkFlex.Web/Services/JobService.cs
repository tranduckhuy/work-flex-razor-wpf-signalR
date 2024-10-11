using AutoMapper;
using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Repository.Interface;
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

        public async Task<(IEnumerable<JobPostDto> JobDtos, int TotalCount)> GetJobsAsync(JobPostVM filters)
        {
            _logger.LogInformation("[GetJobsAsync]: Service - Start getting job list data");
            try
            {
                var (jobs, totalCount) = await _jobRepository.GetJobsAsync(filters);
                var jobDtos = _mapper.Map<IEnumerable<JobPostDto>>(jobs);

                foreach (var jobDto in jobDtos)
                {
                    jobDto.DisplayBriefLocation = FormatJobLocation(jobDto.JobLocation);
                    jobDto.DisplayCreatedAt = FormatDisplayCreatedAt(jobDto.CreatedAt);
                }
                _logger.LogInformation("[GetJobsAsync]: Service - End getting job list data with data: List-data: {jobDtos}, Total-count: {totalCount}", jobDtos, totalCount);
                return (jobDtos, totalCount);
            } catch (Exception ex)
            {
                _logger.LogError("[GetJobsAsync]: Service - End getting job list data with error: {ex}", ex.StackTrace);
                return ([], 0);
            }
        }

        public async Task<IEnumerable<JobType>> GetJobTypesAsync()
        {
            return await _jobRepository.GetJobTypesAsync();
        }

        public async Task<JobPostDto?> GetJobByIdAsync(Guid id)
        {
            var jobPost = await _jobRepository.GetJobByIdAsync(id);
            if (jobPost != null)
            {
                var jobDto = _mapper.Map<JobPostDto>(jobPost);

                jobDto.DisplayBriefLocation = FormatJobLocation(jobDto.JobLocation);
                jobDto.DisplayCreatedAt = FormatDisplayCreatedAt(jobDto.CreatedAt);

                return jobDto;
            }
            return null;
        }

        private string FormatJobLocation(string jobLocation)
        {
            if (string.IsNullOrEmpty(jobLocation))
                return jobLocation;

            var jobLocationParts = jobLocation.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return jobLocationParts.LastOrDefault()?.Trim() ?? string.Empty;
        }

        private string FormatDisplayCreatedAt(DateTime createdAt)
        {
            var timeDifference = DateTime.UtcNow.Date - createdAt.Date;

            if (timeDifference.TotalDays > 5)
            {
                return createdAt.ToString("dd/MM/yyyy");
            }
            else
            {
                int daysAgo = (int)timeDifference.TotalDays;
                return daysAgo > 0 ? $"{daysAgo} Days Ago" : "Today";
            }
        }
    }
}
