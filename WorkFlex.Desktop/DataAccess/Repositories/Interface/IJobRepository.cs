using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.DataAccess.Repositories.Interface
{
    public interface IJobRepository
    {
        void Add(JobPost jobpost);

        JobPost? GetJobPostById(string id);

        IEnumerable<JobPost> List();

        IEnumerable<JobType> GetAllJobTypes();

        IEnumerable<Industry> GetAllIndustries();

        JobPost? GetJobById(Guid id);
    }
}
