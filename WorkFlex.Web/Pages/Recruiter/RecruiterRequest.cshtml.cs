using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Recruiter
{
    public class RecruiterRequestModel : PageModel
    {
        private readonly IUserService _userService;

        public RecruiterRequestModel(IUserService userService)
        {
            _userService = userService;
        }

        public SearchCriteria SearchCriteria { get; set; } = null!;
        public ICollection<UserVM> Users { get; set; } = [];
        public Pageable<SearchCriteria> Pageable { get; set; } = new Pageable<SearchCriteria>();

        public async Task<IActionResult> OnPostCheckUserInfo(Guid userId)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            if (userId == Guid.Empty)
            {
                return new JsonResult(new { success = false, message = "Invalid User ID" });
            }

            try
            {
                if (await _userService.RequestRecruiterApproval(userId))
                {
                    return new JsonResult(new { success = true });
                }
                else
                {
                    return new JsonResult(new { success = false });
                }
            } catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> OnGetDeclineRequest(Guid userId)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            if (userId == Guid.Empty)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }

            try
            {
                await _userService.DeclineRecruiterRequest(userId, HttpContext.Session, HttpContext);
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_DECLINE_RECRUITER_REQUEST_SUCCESSFULLY;
                return RedirectToPage(AppConstants.PAGE_RECRUITER_REQUEST);
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }

        public async Task<IActionResult> OnGetApproveRequest(Guid userId)
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);
            if (currentUserId == null)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            if (userId == Guid.Empty)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }

            try
            {
                await _userService.ApproveRecruiterRequest(userId, HttpContext.Session, HttpContext);
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_APPROVE_RECRUITER_REQUEST_SUCCESSFULLY;
                return RedirectToPage(AppConstants.PAGE_RECRUITER_REQUEST);
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }

        public async Task<IActionResult> OnGet(int currentPage = 1, string searchOption = null!, string searchValue = null!)
        {
            if (!string.IsNullOrEmpty(searchOption) && !string.IsNullOrEmpty(searchValue))
            {
                SearchCriteria = new SearchCriteria
                {
                    SearchOption = searchOption,
                    SearchValue = searchValue
                };
            }
            return await LoadUsers(currentPage, SearchCriteria);
        }

        public async Task<IActionResult> OnPost(SearchCriteria searchCriteria, int currentPage = 1)
        {
            return await LoadUsers(currentPage, searchCriteria);
        }

        private async Task<IActionResult> LoadUsers(int currentPage, SearchCriteria searchCriteria)
        {
            try
            {
                var (users, pageable) = await _userService.GetUsers(currentPage, searchCriteria, 
                    (int)AppConstants.Role.JobSeeker, u => u.IsRecruiterRequestPending);
                Users = AppMapper.Mapper.Map<ICollection<UserVM>>(users);
                Pageable = pageable;
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }
    }
}
