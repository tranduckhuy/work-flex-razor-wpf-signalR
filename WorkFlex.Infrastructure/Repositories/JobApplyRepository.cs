using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Infrastructure.Repositories
{
    public class JobApplyRepository : IJobApplyRepository
    {
        private readonly AppDbContext _context;

        public JobApplyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(ICollection<JobApplication>, Pageable<SearchCriteria>)> GetJobApplicationsAsync(Guid jobPostId,
            SearchCriteria? searchCriteria, int page)
        {
            const int pageSize = 6;

            if (jobPostId == Guid.Empty)
            {
                throw new ArgumentException("Job post ID is required.");
            }

            var query = _context.JobApplications
                .Include(ja => ja.JobPost)
                .Include(ja => ja.User)
                .Where(ja => ja.JobPostId == jobPostId)
                .AsQueryable();

            if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.SearchValue))
            {
                string searchValue = searchCriteria.SearchValue.ToLower().Trim();
                switch (searchCriteria.SearchOption)
                {
                    case nameof(AppConstants.UserSearchOption.Name):
                        query = query.Where(u =>
                            EF.Functions.Like(
                                EF.Functions.Collate((u.User.FirstName + " " + u.User.LastName), "Latin1_General_CI_AI"),
                                $"%{searchValue}%"
                            )
                        );
                        break;

                    case nameof(AppConstants.UserSearchOption.Email):
                        query = query.Where(u => u.User.Email.ToLower().Contains(searchValue));
                        break;

                    default:
                        break;
                }
            }

            int totalUsers = await query.CountAsync();

            var pageable = new Pageable<SearchCriteria>(totalUsers, page, pageSize)
            {
                SearchCriteria = searchCriteria
            };

            int skipAmount = (pageable.CurrentPage - 1) * pageSize;
            var jobApplications = await query.Skip(skipAmount)
                .Take(pageSize)
                .ToListAsync();

            return (jobApplications, pageable);
        }

        public async Task<bool> IsUserPostOwnerAsync(Guid userId, Guid jobPostId)
        {
            var jobPost = await _context.JobPosts.FindAsync(jobPostId);
            if (jobPost == null) return false;

            return jobPost.UserId == userId;
        }
    }
}
