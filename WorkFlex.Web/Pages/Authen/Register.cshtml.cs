using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Authen
{
    public class RegisterModel : PageModel
    {
        public RegisterVM RegisterVM { get; set; } = null!;
        private readonly IAuthenService _authenService;

        public RegisterModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(RegisterVM registerVM)
        {
            try
            {
                var registerResult = _authenService.addUser(registerVM);
                switch (registerResult)
                {
                    case AppConstants.RegisterResult.Success:
                        TempData[AppConstants.TEMP_DATA_MESSAGE_REGISTER_SUCCESS] = AppConstants.MESSAGE_REGISTER_SUCCESS;
                        return RedirectToPage(AppConstants.PAGE_LOGIN);
                    case AppConstants.RegisterResult.EmailExist:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_EMAIL_EXIST;
                        break;
                    case AppConstants.RegisterResult.NotMatchPassword:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_NOT_MATCH_PASSWORD;
                        break;
                    default:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_FAILED;
                        break;
                }
            }
            catch
            {
                TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_FAILED;
                return Page();
            }
            return Page();
        }
    }
}
