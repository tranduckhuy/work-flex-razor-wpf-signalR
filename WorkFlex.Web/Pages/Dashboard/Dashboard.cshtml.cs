using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Web.Pages.Dashboard
{
	public class DashboardModel : PageModel
	{
		private readonly ILogger<DashboardModel> _logger;
		private readonly IDashboardService _dashboardService;

		public DashboardModel(ILogger<DashboardModel> logger, IDashboardService dashboardService)
		{
			_logger = logger;
			_dashboardService = dashboardService;
		}

		public DashboardDto? DashboardData { get; private set; }

		public async Task<IActionResult> OnGetAsync()
		{
			_logger.LogInformation("[OnGetAsync]: Controller - Start loading dashboard data");

			try
			{
				// Get data
				DashboardData = await _dashboardService.GetDashboardData();
				_logger.LogDebug("[OnGetAsync]: Controller - Data: {data}", DashboardData);

				if (DashboardData == null)
				{
					_logger.LogWarning("[OnGetAsync]: Controller - No data returned from DashboardService");
					return NotFound();
				}

				_logger.LogInformation("[OnGetAsync]: Controller - Successfully loaded dashboard data");

				return Page();
			}
			catch (Exception ex)
			{
				_logger.LogError("[OnGetAsync]: Controller - Error fetching dashboard data: {error}", ex.StackTrace);
				return Content(ex.ToString());
			}
		}
	}
}
