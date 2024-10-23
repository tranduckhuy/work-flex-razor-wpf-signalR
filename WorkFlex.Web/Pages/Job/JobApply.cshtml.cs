using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Job
{
    public class JobApplyModel : PageModel
    {

        private readonly AppDbContext _context;
        private readonly ILogger<JobApplyModel> _logger;

        public JobApplyModel(AppDbContext context, ILogger<JobApplyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public JobPost JobPost { get; set; } = null!;
        public JobApplyVM JobApplyVM { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(Guid jobPostId)
        {

            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            var jobPost = await _context.JobPosts.FindAsync(jobPostId);

            if (jobPost == null)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }

            JobPost = jobPost;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(JobApplyVM jobApplyVM)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var jobApplication = new JobApplication
                    {
                        Id = Guid.NewGuid(),
                        JobPostId = jobApplyVM.JobPostId,
                        UserId = new Guid(currentUserId),
                        Description = jobApplyVM.Description,
                        CvFile = jobApplyVM.CVUrl,
                        Status = Status.Pending,
                        ApplicationDate = DateTime.UtcNow
                    };

                    _context.JobApplications.Add(jobApplication);
                    await _context.SaveChangesAsync();
                    TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_APPLY_JOB_SUCCESSFULLY;
                    return RedirectToPage(AppConstants.PAGE_JOB_LIST);
                }
                return Page();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during applying job.");
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }
        }
    }
}
