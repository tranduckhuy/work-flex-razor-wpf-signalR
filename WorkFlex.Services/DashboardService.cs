using Microsoft.Extensions.Logging;
using WorkFlex.Domain.Repositories;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Services
{
	public class DashboardService : IDashboardService
	{
		private readonly ILogger<DashboardService> _logger;
		private readonly IDashboardRepository _dashboardRepository;

		public DashboardService(ILogger<DashboardService> logger, IDashboardRepository dashboardRepository)
		{
			_logger = logger;
			_dashboardRepository = dashboardRepository;
		}

		public async Task<DashboardDto?> GetDashboardData()
		{
			_logger.LogInformation("[GetDashboardData]: Service - Start get data for admin dashboard");

			try
			{
				// Get data from DB for card
				var totalUser = await _dashboardRepository.TotalUser();
				var totalRecruiter = await _dashboardRepository.TotalRecruiter();
				var totalJobPost = await _dashboardRepository.TotalJobPost();
				var totalApplicant = await _dashboardRepository.TotalApplicant();
				// Get data from DB for chart
				var totalUserMonth = await _dashboardRepository.TotalUserMonth();
				var totalRecruiterMonth = await _dashboardRepository.TotalRecruiterMonth();
				var totalJobPostMonth = await _dashboardRepository.TotalJobPostMonth();
				var totalApplicantMonth = await _dashboardRepository.TotalApplicantMonth();

				// Create DashboardDto object for result return
				var dashboardData = new DashboardDto
				{
					// Data for card
					TotalUser = totalUser,
					TotalRecruiter = totalRecruiter,
					TotalJobPost = totalJobPost,
					TotalApplicant = totalApplicant,
					// Data for chart
					TotalUserMonth = totalUserMonth,
					TotalRecruiterMonth = totalRecruiterMonth,
					TotalJobPostMonth = totalJobPostMonth,
					TotalApplicantMonth = totalApplicantMonth
				};
				_logger.LogDebug("[GetDashboardData]: Service - Data: {data}", dashboardData);

				_logger.LogInformation("[GetDashboardData]: Service - End get data for admin dashboard with status: Fetch Data Successfully!");
				return dashboardData;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("[GetDashboardData]: Service - End get data for admin dashboard with error: {error}", ex.StackTrace);
				return null;
			}
		}
	}
}
