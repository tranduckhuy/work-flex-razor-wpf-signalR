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
            _logger.LogInformation("[OnGetAsync]: Start fetching job list with filters: {filters}", filters);

            try
            {
                // Retrieve filters from the session
                var sessionFilters = HttpContext.Session.GetObject<JobPostVM>("JobFilters");

                if (sessionFilters != null && !_jobFilterHelper.IsFilterEmpty(sessionFilters))
                {
                    // If incoming filters are empty, use session filters
                    if (_jobFilterHelper.IsFilterEmpty(filters))
                    {
                        filters = sessionFilters; // Use session filters
                    }
                    else
                    {
                        // Update session if filters have changed
                        if (!_jobFilterHelper.AreFiltersEqual(filters, sessionFilters))
                        {
                            HttpContext.Session.SetObject("JobFilters", filters);
                        }
                    }
                }
                else
                {
                    // Save new filters to session if no previous filters exist
                    HttpContext.Session.SetObject("JobFilters", filters);
                }

                // Set the filters
                Filters = filters;

                // Get jobs based on filters
                (Jobs, TotalCount, TotalPages) = await _jobService.GetJobsAsync(AppMapper.Mapper.Map<JobFilter>(filters));
                _logger.LogDebug("[OnGetAsync]: Jobs retrieved: {Jobs}", Jobs);

                // Get filter options (JobTypes)
                JobTypes = await _jobService.GetJobTypesAsync();
                _logger.LogDebug("[OnGetAsync]: Job types: {JobTypes}", JobTypes);

                // Ensure current page is valid
                CurrentPage = filters.PageNumber > 1 ? filters.PageNumber : 1;
                if (TotalPages < CurrentPage)
                {
                    filters.PageNumber = 1;
                    CurrentPage = 1;
                }

                _logger.LogInformation("[OnGetAsync]: Successfully fetched job list with {Jobs} jobs and {TotalCount} total count", Jobs, TotalCount);
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError("[OnGetAsync]: Error fetching job list: {Error}", ex);
                return Content(ex.ToString());
            }
        }
    }
}
