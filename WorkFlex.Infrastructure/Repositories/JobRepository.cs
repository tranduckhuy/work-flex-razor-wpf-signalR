using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _appDbContext;
        private static readonly char[] separator = [','];

        public JobRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<(IEnumerable<JobPost> Jobs, int TotalCount)> GetJobsAsync(JobFilter filters)
        {
            var query = _appDbContext.JobPosts
                .Include(j => j.JobType)
                .Include(i => i.Industry)
                .Include(u => u.User)
                .Include(ja => ja.JobApplications)
                .AsQueryable();

            // Filter by Status (Status == Status.Active)
            query = query.Where(j => j.Status == Status.Active);

            // Filter by Job Location
            if (!string.IsNullOrEmpty(filters.JobLocation) && filters.JobLocation != AppConstants.ANY_WHERE)
            {
                string normalizedJobLocation = filters.JobLocation.ToLower()
                                    .Replace("thành phố", "")
                                    .Replace("tỉnh", "")
                                    .Trim();
                query = query.Where(j => j.JobLocation.ToLower().Contains(normalizedJobLocation));
            }

            // Filter by Job Type
            if (!string.IsNullOrEmpty(filters.JobType) && filters.JobType != AppConstants.ALL)
            {
                var jobTypes = filters.JobType.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(j => jobTypes.Contains(j.JobType.TypeName));
            }

            // Filter by Posted Within
            if (!string.IsNullOrEmpty(filters.PostedWithin) && filters.PostedWithin != AppConstants.ANY)
            {
                DateTime fromDate = DateTime.UtcNow.Date;
                bool hasFilter = false;

                switch (filters.PostedWithin.Trim())
                {
                    case "Today":
                        fromDate = DateTime.UtcNow.Date;
                        hasFilter = true;
                        break;
                    case "Last 2 days":
                        fromDate = DateTime.UtcNow.Date.AddDays(-2);
                        hasFilter = true;
                        break;
                    case "Last 3 days":
                        fromDate = DateTime.UtcNow.Date.AddDays(-3);
                        hasFilter = true;
                        break;
                    case "Last 5 days":
                        fromDate = DateTime.UtcNow.Date.AddDays(-5);
                        hasFilter = true;
                        break;
                    case "Last 10 days":
                        fromDate = DateTime.UtcNow.Date.AddDays(-10);
                        hasFilter = true;
                        break;
                }

                if (hasFilter)
                {
                    query = query.Where(j => j.CreatedAt.Date >= fromDate);
                }
            }

            // Fetch the jobs with salary filtering applied
            var jobPosts = await query.ToListAsync();

            // Filter based on salary range
            if (filters.MinSalary.HasValue && filters.MaxSalary.HasValue)
            {
                jobPosts = jobPosts.Where(job =>
                        job.SalaryRange.Contains('-') &&
                        TryParseSalaryRange(job.SalaryRange, out decimal minSalary, out decimal maxSalary) &&
                        (filters.MinSalary.Value == 0 && filters.MaxSalary.Value == 0 ||
                        minSalary >= filters.MinSalary.Value && maxSalary <= filters.MaxSalary.Value))
                    .ToList();
            }

            // Sorting
            if (!string.IsNullOrEmpty(filters.SortBy) && filters.SortBy != AppConstants.NONE)
            {
                // Sort after filtering the jobs
                switch (filters.SortBy)
                {
                    case "SalaryLowToHigh":
                        jobPosts = jobPosts
                            .Where(job => !string.IsNullOrEmpty(job.SalaryRange) && job.SalaryRange.Contains('-'))
                            .OrderBy(job => GetMinSalary(job.SalaryRange))
                            .ToList();
                        break;

                    case "SalaryHighToLow":
                        jobPosts = jobPosts
                            .Where(job => !string.IsNullOrEmpty(job.SalaryRange) && job.SalaryRange.Contains('-'))
                            .OrderByDescending(job => GetMinSalary(job.SalaryRange))
                            .ToList();
                        break;

                    default:
                        jobPosts = jobPosts.OrderByDescending(job => job.CreatedAt).ToList();
                        break;
                }
            }
            else
            {
                jobPosts = jobPosts.OrderByDescending(job => job.CreatedAt).ToList();
            }

            // Get total count before pagination
            int totalCount = jobPosts.Count;

            // Pagination on the filtered jobs
            var jobs = jobPosts
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .ToList();

            return (jobs, totalCount);
        }

        public async Task<IEnumerable<JobType>> GetJobTypesAsync()
        {
            return await _appDbContext.JobTypes.ToListAsync();
        }

        public async Task<IEnumerable<Industry>> GetIndustriesAsync()
        {
            return await _appDbContext.Industries.ToListAsync();
        }

        public async Task<JobPost> GetJobByIdAsync(Guid id)
        {
            var jobPost = await _appDbContext.JobPosts
                .Include(j => j.JobType)
                .Include(i => i.Industry)
                .Include(u => u.User)
                .Include(ja => ja.JobApplications)
                .FirstOrDefaultAsync(j => j.Id == id);

            return jobPost!;
        }

        public async Task AddJobPostAsync(JobPost jobPost)
        {
            await _appDbContext.JobPosts.AddAsync(jobPost);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateJobPostAsync(JobPost jobPost)
        {
            _appDbContext.Update(jobPost);
            await _appDbContext.SaveChangesAsync();
        }

        private static bool TryParseSalaryRange(string salaryRange, out decimal minSalary, out decimal maxSalary)
        {
            minSalary = 0;
            maxSalary = 0;

            var parts = salaryRange.Split('-');
            if (parts.Length == 2 &&
                decimal.TryParse(parts[0], out minSalary) &&
                decimal.TryParse(parts[1], out maxSalary))
            {
                return true;
            }

            return false;
        }

        private static decimal GetMinSalary(string salaryRange)
        {
            if (TryParseSalaryRange(salaryRange, out decimal minSalary, out _))
            {
                return minSalary;
            }
            return decimal.MaxValue;
        }
    }
}
