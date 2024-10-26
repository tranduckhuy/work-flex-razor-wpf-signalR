using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Job
{
    public class JobPostsModel : PageModel
    {
        private readonly IJobService _jobService;

        public JobPostsModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        public SearchCriteria SearchCriteria { get; set; } = null!;
        public ICollection<JobPostVM> JobPostVM { get; set; } = [];
        public Pageable<SearchCriteria> Pageable { get; set; } = new Pageable<SearchCriteria>();
        public Guid UserId { get; set; }

        public async Task<IActionResult> OnGet(Guid userId, string searchOption = default!, 
            string searchValue = default!, int currentPage = 1)
        {
            if (!string.IsNullOrEmpty(searchOption) && !string.IsNullOrEmpty(searchValue))
            {
                SearchCriteria = new SearchCriteria
                {
                    SearchOption = searchOption.Trim(),
                    SearchValue = searchValue.Trim()
                };
            }
            return await LoadJobPosts(userId, SearchCriteria, currentPage);
        }

        public async Task<IActionResult> OnPost(Guid userId, SearchCriteria searchCriteria, int currentPage = 1)
        {
            return await LoadJobPosts(userId, searchCriteria, currentPage);
        }

        private async Task<IActionResult> LoadJobPosts(Guid userId, SearchCriteria searchCriteria, int currentPage)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            var roleIdBytes = HttpContext.Session.Get(AppConstants.ROLE);

            if (roleIdBytes != null)
            {
                var roleId = BitConverter.ToInt32(roleIdBytes, 0);
                if (roleId == (int)AppConstants.Role.JobSeeker || userId != Guid.Parse(currentUserId))
                {
                    TempData[AppConstants.MESSAGE_FAILED] = AppConstants.MESSAGE_UNAUTHORIZED_ACTION;
                    return RedirectToPage(AppConstants.PAGE_HOME);
                }
            }

            try
            {
                var (jobPosts, pageable) = await _jobService.GetJobsByUserIdAsync(currentPage, userId, searchCriteria);
                JobPostVM = AppMapper.Mapper.Map<ICollection<JobPostVM>>(jobPosts);
                Pageable = pageable;
                UserId = userId;
                return Page();
            }
            catch (Exception ex)
            {
                TempData[AppConstants.MESSAGE_FAILED] = ex.Message;
                return Page();
            }
        }
    }
}
