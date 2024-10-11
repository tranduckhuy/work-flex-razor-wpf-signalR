using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain.Entities;
using WorkFlex.Web.ViewModels;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.DTOs;

namespace WorkFlex.Web.Pages.Job
{
    public class JobListModel : PageModel
    {
        private readonly ILogger<JobListModel> _logger;
        private readonly IJobService _jobService;

        public JobListModel(ILogger<JobListModel> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        public IEnumerable<JobPostDto> Jobs { get; set; } = new List<JobPostDto>();

        public JobPostVM Filters { get; set; } = null!;

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 7;

        public IEnumerable<string> JobLocations { get; set; } = new List<string>();

        public IEnumerable<JobType> JobTypes { get; set; } = new List<JobType>();

        public async Task<IActionResult> OnGetAsync(JobPostVM filters)
        {
            _logger.LogInformation("[OnGetAsync]: PageModel - Start getting job list data with request data: Req-data: {filters}", filters);
            try
            {
               
                CurrentPage = filters.PageNumber > 1 ? filters.PageNumber : 1;

                // Get jobs based on filters
                (Jobs, TotalCount) = await _jobService.GetJobsAsync(filters);
                _logger.LogDebug("[OnGetAsync]: Jobs retrieved: {Jobs}", Jobs);

                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                // Get filter options
                JobTypes = await _jobService.GetJobTypesAsync();
                _logger.LogDebug("[OnGetAsync]: PageModel - Job types: {JobTypes}", JobTypes);

                _logger.LogInformation("[OnGetAsync]: PageModel - End getting job list data with data: Resp-data: {Jobs}, Total-count: {TotalCount}", Jobs, TotalCount);
                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("[OnGetAsync]: PageModel - End getting job list data with error: {ex}", ex.StackTrace);
                return Content(ex.ToString());
            }
        }
    }
}
