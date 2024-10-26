using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Job
{
    public class ApplicantListModel : PageModel
    {
        private readonly IJobApplyService _jobApplyService;

        public ApplicantListModel(IJobApplyService jobApplyService)
        {
            _jobApplyService = jobApplyService;
        }

        public SearchCriteria SearchCriteria { get; set; } = null!;
        public ICollection<JobApplicantVM> JobApplicants { get; set; } = [];
        public Pageable<SearchCriteria> Pageable { get; set; } = new Pageable<SearchCriteria>();
        public Guid JobPostId { get; set; }

        public async Task<IActionResult> OnGet(Guid jobPostId,
            string searchOption = default!, string searchValue = default!, int currentPage = 1)
        {
            if (!string.IsNullOrEmpty(searchOption) && !string.IsNullOrEmpty(searchValue))
            {
                SearchCriteria = new SearchCriteria
                {
                    SearchOption = searchOption.Trim(),
                    SearchValue = searchValue.Trim()
                };
            }
            return await LoadJobApplicants(jobPostId, SearchCriteria, currentPage);
        }

        public async Task<IActionResult> OnPost(Guid jobPostId, SearchCriteria searchCriteria, int currentPage = 1)
        {
            return await LoadJobApplicants(jobPostId, searchCriteria, currentPage);
        }

        private async Task<IActionResult> LoadJobApplicants(Guid jobPostId, SearchCriteria searchCriteria, int currentPage)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            var roleIdBytes = HttpContext.Session.Get(AppConstants.ROLE);
            
            if (roleIdBytes != null) {
                var roleId = BitConverter.ToInt32(roleIdBytes, 0);
                if (roleId == (int)AppConstants.Role.JobSeeker)
                {
                    TempData[AppConstants.MESSAGE_FAILED] = AppConstants.MESSAGE_UNAUTHORIZED_ACTION;
                    return RedirectToPage(AppConstants.PAGE_HOME);
                }
            } 

            try
            {
                // Check if the current user is the owner of the job post
                var isPostOwner = await _jobApplyService.IsUserPostOwnerAsync(new Guid(currentUserId), jobPostId);
                if (!isPostOwner)
                {
                    TempData[AppConstants.MESSAGE_FAILED] = AppConstants.MESSAGE_UNAUTHORIZED_ACTION;
                    return RedirectToPage(AppConstants.PAGE_HOME);
                }

                var (jobApplicants, pageable) = await _jobApplyService.GetJobApplicationsAsync(jobPostId, searchCriteria, currentPage);
                JobApplicants = AppMapper.Mapper.Map<ICollection<JobApplicantVM>>(jobApplicants);
                Pageable = pageable;
                JobPostId = jobPostId;
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
