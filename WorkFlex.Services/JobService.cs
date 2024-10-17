using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Domain.Repositories;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;

namespace WorkFlex.Services
{
    public class JobService : IJobService
    {
        private readonly ILogger<JobService> _logger;
        private readonly IJobRepository _jobRepository;

        public JobService(ILogger<JobService> logger, IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }


        public async Task<bool> AddJobPostAsync(JobPostDto jobPostDto)
        {
            _logger.LogInformation("[AddJobPostAsync]: Service - Start add a job with information: {jobPostDto}", jobPostDto);
            try
            {
                var jobPost = new JobPost
                {
                    Title = jobPostDto.Title,
                    SalaryRange = jobPostDto.SalaryRange,
                    JobDescription = jobPostDto.JobDescription,
                    JobLocation = jobPostDto.JobLocation,
                    JobTypeId = jobPostDto.JobTypeId,
                    IndustryId = jobPostDto.IndustryId,
                    UserId = jobPostDto.UserId,
                    Status = jobPostDto.Status
                };
                _logger.LogDebug("[AddJobPostAsync]: Service - Job will be added into DB: {jobPost}", jobPost);

                await _jobRepository.AddJobPostAsync(jobPost);
                _logger.LogInformation("[AddJobPostAsync]: Service - End add a job with message: Added successfully.");

                return true;
            } catch (Exception ex)
            {
                _logger.LogInformation("[AddJobPostAsync]: Service - End add a job with error: {ex}", ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> UpdateJobPostAsync(JobPostDto jobPostDto)
        {
            _logger.LogInformation("[UpdateJobPostAsync]: Service - Start update a job with information: {jobPostDto}", jobPostDto);
            try
            {
                var oldJob = await _jobRepository.GetJobByIdAsync(jobPostDto.Id);
                if (oldJob == null)
                {
                    _logger.LogInformation("[UpdateJobPostAsync]: Service - End update a job with message: Job not found.");
                    return false;
                }
                _logger.LogDebug("[UpdateJobPostAsync]: Service - Job before update: {oldJob}", oldJob);

                oldJob.Title = jobPostDto.Title;
                oldJob.SalaryRange = jobPostDto.SalaryRange;
                oldJob.JobDescription = jobPostDto.JobDescription;
                oldJob.JobLocation = jobPostDto.JobLocation;
                oldJob.JobTypeId = jobPostDto.JobTypeId;
                oldJob.IndustryId = jobPostDto.IndustryId;
                _logger.LogDebug("[UpdateJobPostAsync]: Service - Job after update: {oldJob}", oldJob);

                await _jobRepository.UpdateJobPostAsync(oldJob);
                _logger.LogInformation("[UpdateJobPostAsync]: Service - End update a job with message: Updated successfully.");
                return true;
            } catch (Exception ex)
            {
                _logger.LogInformation("[UpdateJobPostAsync]: Service - End update a job with error: {ex}", ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteJobPostAsync(Guid id)
        {
            _logger.LogInformation("[DeleteJobPostAsync]: Service - Start delete a job with id: {id}", id);
            try
            {
                var oldJob = await _jobRepository.GetJobByIdAsync(id);
                if (oldJob == null)
                {
                    _logger.LogInformation("[DeleteJobPostAsync]: Service - End delete a job with message: Job not found.");
                    return false;
                }
                _logger.LogDebug("[DeleteJobPostAsync]: Service - Job before delete: {oldJob}", oldJob);
                oldJob.Status = Status.Inactive;
                _logger.LogDebug("[DeleteJobPostAsync]: Service - Job after delete: {oldJob}", oldJob);

                await _jobRepository.UpdateJobPostAsync(oldJob);
                _logger.LogInformation("[DeleteJobPostAsync]: Service - End delete a job with message: Deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("[DeleteJobPostAsync]: Service - End delete a job with error: {ex}", ex.StackTrace);
                return false;
            }
        }

        public async Task<(IEnumerable<JobPostDto> JobDtos, int TotalCount)> GetJobsAsync(JobFilter filters)
        {
            _logger.LogInformation("[GetJobsAsync]: Service - Start getting job list data");
            try
            {
                var (jobs, totalCount) = await _jobRepository.GetJobsAsync(filters);
                var jobDtos = AppMapper.Mapper.Map<IEnumerable<JobPostDto>>(jobs);

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

        public async Task<IEnumerable<Industry>> GetIndustriesAsync()
        {
            return await _jobRepository.GetIndustriesAsync();
        }

        public async Task<JobPostDto?> GetJobByIdAsync(Guid id)
        {
            var jobPost = await _jobRepository.GetJobByIdAsync(id);
            if (jobPost != null)
            {
                var jobDto = AppMapper.Mapper.Map<JobPostDto>(jobPost);

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
