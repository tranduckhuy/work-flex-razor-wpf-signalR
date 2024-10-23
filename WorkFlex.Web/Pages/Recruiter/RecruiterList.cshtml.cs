using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Domain;
using WorkFlex.Domain.SearchCiteria;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Recruiter
{
    public class RecruiterListModel : PageModel
    {
        private readonly IUserService _userService;

        public RecruiterListModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserSearchCriteria SearchCriteria { get; set; } = null!;
        public ICollection<UserVM> Users { get; set; } = [];
        public Pageable<UserSearchCriteria> Pageable { get; set; } = new Pageable<UserSearchCriteria>();

        public async Task<IActionResult> OnGet(int currentPage = 1, string searchOption = null!, string searchValue = null!)
        {
            if (!string.IsNullOrEmpty(searchOption) && !string.IsNullOrEmpty(searchValue))
            {
                SearchCriteria = new UserSearchCriteria
                {
                    SearchOption = searchOption,
                    SearchValue = searchValue
                };
            }
            return await LoadUsers(currentPage, SearchCriteria);
        }

        public async Task<IActionResult> OnPost(UserSearchCriteria searchCriteria, int currentPage = 1)
        {
            return await LoadUsers(currentPage, searchCriteria);
        }

        private async Task<IActionResult> LoadUsers(int currentPage, UserSearchCriteria searchCriteria)
        {
            try {
                var (users, pageable) = await _userService.GetUsers(currentPage, searchCriteria, (int)AppConstants.Role.Recruiter);
                Users = AppMapper.Mapper.Map<ICollection<UserVM>>(users);
                Pageable = pageable;
                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }

        public async Task<IActionResult> OnGetLockUnlockUser(Guid userId)
        {
            try
            {
                await _userService.LockUnlockUser(userId);
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_ACTION_SUCCESSFULLY;
                return RedirectToPage(); 
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }

        public async Task<IActionResult> OnGetDemotePromoteUser(Guid userId)
        {
            try
            {
                await _userService.DemotePromoteUser(userId);
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_ACTION_SUCCESSFULLY;
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                return RedirectToPage(AppConstants.PAGE_ERROR, new { message = ex.Message });
            }
        }
    }
}
