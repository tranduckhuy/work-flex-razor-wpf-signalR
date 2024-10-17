using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.BusinessObject.Service.Interface
{
    public interface IJobPostService
    {
        void AddJobPost(JobPostDTO add);

        void UpdateJobPost(JobPostDTO jobPostDTO);

        void DeleteJobPost(Guid jobId);

        JobPostDTO? GetJobPostById(string jobId);

        IEnumerable<JobPostDTO> GetAllJobPosts();

        IEnumerable<JobType> GetAllJobTypes();

        IEnumerable<Industry> GetAllIndustries();

        JobPostDTO? GetJobById(Guid id);

    }
}
