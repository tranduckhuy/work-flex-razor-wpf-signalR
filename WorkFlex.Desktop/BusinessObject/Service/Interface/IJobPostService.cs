using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.BusinessObject.Service.Interface
{
    public interface IJobPostService
    {
        void AddJobPost(JobPostDTO add);

        JobPostDTO? GetJobPostById(string jobId);

        IEnumerable<JobPostDTO> GetAllJobPosts();

        IEnumerable<JobType> GetAllJobTypes();

        IEnumerable<Industry> GetAllIndustries();
    }
}
