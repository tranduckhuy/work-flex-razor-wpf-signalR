using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.Utils.Helper;
using WorkFlex.Web.Utils.Helper.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Job
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class JobListModel : PageModel
    {
        private readonly ILogger<JobListModel> _logger;
        private readonly IJobService _jobService;
        private readonly IJobFilterHelper _jobFilterHelper;

        public JobListModel(ILogger<JobListModel> logger, IJobService jobService, IJobFilterHelper jobFilterHelper)
        {
            _logger = logger;
            _jobService = jobService;
            _jobFilterHelper = jobFilterHelper;
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
                // Retrieve filters from the session
                var sessionFilters = HttpContext.Session.GetObject<JobPostVM>("JobFilters");

                // Check if session filters exist
                if (sessionFilters != null && !_jobFilterHelper.IsFilterEmpty(sessionFilters)) // Check sessionFilters is not null and is not empty
                {
                    // If filters are empty (initial load), use session filters
                    if (_jobFilterHelper.IsFilterEmpty(filters)) // Check filters is empty or not
                    {
                        filters = sessionFilters; // Using session filters if filters is empty
                    }
                    else
                    {
                        // If filters are not equal, update session with current filters
                        if (!_jobFilterHelper.AreFiltersEqual(filters, sessionFilters))
                        {
                            HttpContext.Session.SetObject("JobFilters", filters);
                        }
                    }
                }
                else
                {
                    // Save new filters into the session if no previous filters exist
                    HttpContext.Session.SetObject("JobFilters", filters);
                }

                // Set the filter
                Filters = filters;

                // Set the current page, default to 1 if PageNumber is not greater than 1
                CurrentPage = filters.PageNumber > 1 ? filters.PageNumber : 1;

                // Get jobs based on filters
                (Jobs, TotalCount) = await _jobService.GetJobsAsync(AppMapper.Mapper.Map<JobFilter>(filters));
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
