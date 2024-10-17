﻿using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.BusinessObject.Service.Interface;
using WorkFlex.Desktop.DataAccess.Repositories.Interface;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.BusinessObject.Service
{
    public class JobPostService : IJobPostService
    {

        private readonly IJobRepository _jobRepository;

        public JobPostService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public void AddJobPost(JobPostDTO jobPostDto)
        {
            var jobPost = new JobPost
            {
                Title = jobPostDto.Title,
                SalaryRange = jobPostDto.SalaryRange,
                JobDescription = jobPostDto.JobDescription,
                JobLocation = jobPostDto.JobLocation,
                JobTypeId = jobPostDto.JobTypeId,
                IndustryId = jobPostDto.IndustryId,
                UserId = UserSession.Instance.GetUser().Id,
                Status = jobPostDto.Status
            };
            _jobRepository.Add(jobPost);
        }

        public void UpdateJobPost(JobPostDTO jobPostDto)
        {
            var jobPost = _jobRepository.GetJobById(jobPostDto.Id);
            if (jobPost != null)
            {
                jobPost.Title = jobPostDto.Title;
                jobPost.SalaryRange = jobPostDto.SalaryRange;
                jobPost.JobDescription = jobPostDto.JobDescription;
                jobPost.JobLocation = jobPostDto.JobLocation;
                jobPost.JobTypeId = jobPostDto.JobTypeId;
                jobPost.IndustryId = jobPostDto.IndustryId;
                jobPost.Status = jobPostDto.Status;

                _jobRepository.Update(jobPost);
            }
        }

        public void DeleteJobPost(Guid jobId)
        {
            _jobRepository.Delete(jobId);
        }


        public JobPostDTO? GetJobPostById(string jobId)
        {
            var jobPost = _jobRepository.GetJobPostById(jobId);
            var jobPostDTO = AppMapper.Mapper.Map<JobPostDTO>(jobPost);
            if (jobPostDTO != null)
            {
               return jobPostDTO;
            }
            return null;
        }

        public IEnumerable<JobPostDTO> GetAllJobPosts()
        {
            var jobPosts = _jobRepository.List();
            return jobPosts.Select(AppMapper.Mapper.Map<JobPostDTO>);
        }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            return _jobRepository.GetAllJobTypes();
        }

        public IEnumerable<Industry> GetAllIndustries()
        {
            return _jobRepository.GetAllIndustries();
        }

        public JobPostDTO? GetJobById(Guid id) 
        {
            var jobPost = _jobRepository.GetJobById(id);
            if (jobPost != null)
            {
                var jobDto = AppMapper.Mapper.Map<JobPostDTO>(jobPost);
                jobDto.DisplayBriefLocation = DesktopFormatJobLocation(jobDto.JobLocation);
                jobDto.DisplayCreatedAt = DesktopFormatDisplayCreatedAt(jobDto.CreatedAt);
                return jobDto; 
            }
            return null;
        }

        private string DesktopFormatJobLocation(string jobLocation)
        {
            if (string.IsNullOrEmpty(jobLocation))
                return jobLocation;

            var jobLocationParts = jobLocation.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return jobLocationParts.LastOrDefault()?.Trim() ?? string.Empty;
        }

        private string DesktopFormatDisplayCreatedAt(DateTime createdAt)
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
