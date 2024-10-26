using WorkFlex.Domain;
using WorkFlex.Domain.Repositories;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;

namespace WorkFlex.Services
{
    public class JobApplyService : IJobApplyService
    {
        private readonly IJobApplyRepository _jobApplyRepository;

        public JobApplyService(IJobApplyRepository jobApplyRepository)
        {
            _jobApplyRepository = jobApplyRepository;
        }

        public async Task<(ICollection<JobApplicantDto>, Pageable<SearchCriteria>)> GetJobApplicationsAsync(Guid jobPostId, 
            SearchCriteria? searchCriteria, int page)
        {
            var result = await _jobApplyRepository.GetJobApplicationsAsync(jobPostId, searchCriteria, page);
            return (AppMapper.Mapper.Map<ICollection<JobApplicantDto>>(result.Item1), result.Item2);
        }

        public async Task<bool> IsUserPostOwnerAsync(Guid userId, Guid jobPostId)
        {
            return await _jobApplyRepository.IsUserPostOwnerAsync(userId, jobPostId);
        }
    }
}
