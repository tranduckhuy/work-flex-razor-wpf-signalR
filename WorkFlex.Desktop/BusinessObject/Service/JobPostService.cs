using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.BusinessObject.Service.Interface;
using WorkFlex.Desktop.DataAccess.Repositories;
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
    }
}
