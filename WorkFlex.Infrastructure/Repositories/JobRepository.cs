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

		public async Task<(IEnumerable<JobPost> Jobs, int TotalCount, int TotalPages)> GetJobsAsync(JobFilter filters)
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
					case "Last 5 days":
						fromDate = DateTime.UtcNow.Date.AddDays(-5);
						hasFilter = true;
						break;
					case "Last Week":
						fromDate = DateTime.UtcNow.Date.AddDays(-7);
						hasFilter = true;
						break;
					case "Last Month":
						fromDate = DateTime.UtcNow.Date.AddMonths(-1);
						hasFilter = true;
						break;
					case "Last Year":
						fromDate = DateTime.UtcNow.Date.AddYears(-1);
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

			// Filter by salary range (Min/Max Salary)
			if (filters.MinSalary.HasValue && filters.MaxSalary.HasValue)
			{
				jobPosts = jobPosts.Where(job => IsSalaryRangeValid(job.SalaryRange, filters.MinSalary.Value, filters.MaxSalary.Value))
								   .ToList();
			}

			// Sorting based on the salary range or creation date
			if (!string.IsNullOrEmpty(filters.SortBy) && filters.SortBy != AppConstants.NONE)
			{
				switch (filters.SortBy)
				{
					case "SalaryLowToHigh":
						// Sort by minimum salary, and by maximum salary if min values are the same
						jobPosts = jobPosts
							.Where(job => TryParseSalaryRange(job.SalaryRange, out _, out _)) // Only include valid salary ranges
							.OrderBy(job => GetMinSalary(job.SalaryRange)) // Sort by minimum salary
							.ThenBy(job => GetMaxSalary(job.SalaryRange)) // If min is the same, sort by max salary
							.ToList();
						break;

					case "SalaryHighToLow":
						// Sort by minimum salary in descending order, and by maximum salary if min values are the same
						jobPosts = jobPosts
							.Where(job => TryParseSalaryRange(job.SalaryRange, out _, out _))
							.OrderByDescending(job => GetMinSalary(job.SalaryRange)) // Sort by minimum salary in descending order
							.ThenByDescending(job => GetMaxSalary(job.SalaryRange)) // If min is the same, sort by max salary
							.ToList();
						break;

					default:
						// Default sorting by creation date in descending order
						jobPosts = jobPosts.OrderByDescending(job => job.CreatedAt).ToList();
						break;
				}
			}
			else
			{
				// If no sorting criteria, sort by creation date by default
				jobPosts = jobPosts.OrderByDescending(job => job.CreatedAt).ToList();
			}

			// Get total count before pagination
			int totalCount = jobPosts.Count;

            // Calculate total pages
            int totalPages = (int)Math.Ceiling(totalCount / (double)filters.PageSize);

            // Validate and adjust PageNumber if needed
            if (filters.PageNumber > totalPages && totalPages > 0)
            {
                filters.PageNumber = 1; // Reset to the first page if current page is invalid
            }

            // Pagination on the filtered jobs
            var jobs = jobPosts
				.Skip((filters.PageNumber - 1) * filters.PageSize)
				.Take(filters.PageSize)
				.ToList();

			return (jobs, totalCount, totalPages);
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

		private static bool IsSalaryRangeValid(string salaryRange, decimal minFilter, decimal maxFilter)
		{
			if (TryParseSalaryRange(salaryRange, out decimal minSalary, out decimal maxSalary))
			{
				// Check if the salary range is within the desired filter range, or if the filter is 0 (no filter applied)
				return (minFilter == 0 && maxFilter == 0) ||
					   (minSalary >= minFilter && maxSalary <= maxFilter);
			}
			return false;
		}

		private static bool TryParseSalaryRange(string salaryRange, out decimal minSalary, out decimal maxSalary)
		{
			minSalary = 0;
			maxSalary = 0;

			// Split the salary range string by the '-' character
			var parts = salaryRange.Split('-');
			if (parts.Length == 2 &&
				decimal.TryParse(parts[0], out minSalary) && // Parse the minimum salary part
				decimal.TryParse(parts[1], out maxSalary)) // Parse the maximum salary part
			{
				// Ensure the minimum salary is less than or equal to the maximum salary
				return minSalary <= maxSalary;
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

		private static decimal GetMaxSalary(string salaryRange)
		{
			if (TryParseSalaryRange(salaryRange, out _, out decimal maxSalary))
			{
				return maxSalary;
			}
			return decimal.MinValue;
		}
	}
}
