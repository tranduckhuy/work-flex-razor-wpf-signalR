using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Infrastructure.Repositories
{
	public class DashboardRepository : IDashboardRepository
	{
		private readonly AppDbContext _context;

		public DashboardRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<int> TotalUser()
		{
			return await _context.Users.CountAsync(u => u.RoleId == 3);
		}

		public async Task<int> TotalRecruiter()
		{
			return await _context.Users.CountAsync(u => u.RoleId == 2);
		}

		public async Task<int> TotalJobPost()
		{
			return await _context.JobPosts.CountAsync();
		}

		public async Task<int> TotalApplicant()
		{
			return await _context.JobApplications.CountAsync();
		}

		public async Task<List<int>> TotalUserMonth()
		{
			var groupedData = await _context.Users
				.Where(user => user.RoleId == (int)AppConstants.Role.JobSeeker && user.CreatedAt.Year == DateTime.UtcNow.Year)
				.GroupBy(user => user.CreatedAt.Month)
				.ToListAsync();

			return ProcessMonthlyData(groupedData);
		}

		public async Task<List<int>> TotalRecruiterMonth()
		{
			var groupedData = await _context.Users
				.Where(user => user.RoleId == (int)AppConstants.Role.Recruiter && user.CreatedAt.Year == DateTime.UtcNow.Year)
				.GroupBy(user => user.CreatedAt.Month)
				.ToListAsync();

			return ProcessMonthlyData(groupedData);
		}

		public async Task<List<int>> TotalJobPostMonth()
		{
			var groupedData = await _context.JobPosts
				.Where(jobPost => jobPost.CreatedAt.Year == DateTime.UtcNow.Year)
				.GroupBy(jobPost => jobPost.CreatedAt.Month)
				.ToListAsync();

			return ProcessMonthlyData(groupedData);
		}

		public async Task<List<int>> TotalApplicantMonth()
		{
			var groupedData = await _context.JobApplications
				.Where(application => application.ApplicationDate.Year == DateTime.UtcNow.Year)
				.GroupBy(application => application.ApplicationDate.Month)
				.ToListAsync();

			return ProcessMonthlyData(groupedData);
		}

		private static List<int> ProcessMonthlyData<T>(IEnumerable<IGrouping<int, T>> groupedData)
		{
			// Initialize an array with 12 elements, all set to 0
			var monthlyData = new int[12];

			// Populate the array with counts from the grouped data
			foreach (var group in groupedData)
			{
				monthlyData[group.Key - 1] = group.Count(); // Month is 1-based, so we adjust with -1
			}

			return monthlyData.ToList(); // Convert the array to a list and return it
		}
	}
}
