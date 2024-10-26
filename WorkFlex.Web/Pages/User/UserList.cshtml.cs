using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.User
{
    public class UserListModel : PageModel
    {
        private readonly IUserService _userService;

        public UserListModel(IUserService userService)
        {
            _userService = userService;
        }

        public ICollection<UserVM> Users { get; set; } = [];

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public SearchCriteria SearchCriteria { get; set; } = null!;

        public Pageable<SearchCriteria> Pageable { get; set; } = new Pageable<SearchCriteria>();

        public async Task<IActionResult> OnGetAsync(int currentPage = 1, string searchOption = null!, string searchValue = null!)
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

        public async Task<IActionResult> OnPostAsync(SearchCriteria searchCriteria, int currentPage = 1)
        {
            return await LoadUsers(currentPage, searchCriteria);
        }

        public async Task<IActionResult> OnGetLockUnlockUser(Guid userId)
        {
            try
            {
                var currentUserID = HttpContext.Session.GetString(AppConstants.ID);
                if (currentUserID != (userId.ToString()))
                {
                    await _userService.LockUnlockUser(userId);
                    TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_ACTION_SUCCESSFULLY;
                    return RedirectToPage();
                }
                else
                {
                    TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOCKUNLOCK_USER_FAILED;
                    return RedirectToPage();
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }

        private async Task<IActionResult> LoadUsers(int currentPage, SearchCriteria searchCriteria)
        {
            try
            {
                var (users, pageable) = await _userService.GetUsers(currentPage, searchCriteria, (int)AppConstants.Role.JobSeeker);
                Users = AppMapper.Mapper.Map<ICollection<UserVM>>(users);
                Pageable = pageable;
                return Page();
            }
            catch
            {
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }
        }
    }
}