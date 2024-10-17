using Microsoft.EntityFrameworkCore;
using WorkFlex.Desktop.DataAccess.Repositories.Interface;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Desktop.DataAccess.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(JobPost jobpost)
        {
            _context.JobPosts.Add(jobpost);
            _context.SaveChanges();
        }

        public void Update(JobPost jobPost)
        {
            _context.JobPosts.Update(jobPost);
            _context.SaveChanges();
        }

        public void Delete(Guid jobId)
        {
            var jobPost = _context.JobPosts.Find(jobId);
            if (jobPost != null)
            {
                _context.JobPosts.Remove(jobPost);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("JobPost not found.");
            }
        }


        public JobPost? GetJobPostById(string id)
        {
            var jobPost = _context.JobPosts.FirstOrDefault(j => j.Id.Equals(id));
            if (jobPost == null)
                return null;
            return jobPost;
        }

        public IEnumerable<JobPost> List()
        {
            return _context.JobPosts.ToList(); 
        }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            return _context.JobTypes.ToList();
        }

        public IEnumerable<Industry> GetAllIndustries()
        {
            return _context.Industries.ToList();
        }

        public JobPost? GetJobById(Guid id) 
        {
            var jobPost = _context.JobPosts
                .Include(j => j.JobType)
                .Include(u => u.User) 
                .Include(ja => ja.JobApplications) 
                .FirstOrDefault(j => j.Id == id); 

            return jobPost;
        }
    }
}
