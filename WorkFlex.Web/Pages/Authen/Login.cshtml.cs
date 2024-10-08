using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.ViewModels;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Constants;

namespace WorkFlex.Web.Pages.Authen
{
    public class LoginModel : PageModel
    {
        public LoginVM LoginVM { get; set; } = null!;
        private readonly IAuthenService _authenService;

        public LoginModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        public IActionResult OnGet()
        {
            var username = HttpContext.Session.GetString(AppConstants.USERNAME);
            if (username == null) 
                return Page();
            return RedirectToPage(AppConstants.PAGE_HOME);
            
        }

        public IActionResult OnPost(LoginVM loginVm)
        {
            var usernameSession = HttpContext.Session.GetString(AppConstants.USERNAME);

            if (!string.IsNullOrEmpty(usernameSession) && usernameSession == loginVm.Username)
            {
                return RedirectToPage(AppConstants.PAGE_HOME);
            }

            if (usernameSession == null || usernameSession != loginVm.Username)
            {
                try
                {
                    var loginDto = _authenService.checkLogin(loginVm);
                    switch (loginDto!.Result)
                    {
                        case AppConstants.LoginResult.Success:
                            if (loginDto.User != null)
                            {
                                SetUserSession(loginDto.User);
                                return RedirectToPage(AppConstants.PAGE_HOME);
                            }
                            break;
                        case AppConstants.LoginResult.InvalidPassword:
                            TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_INVALID_PASSWORD;
                            break;
                        case AppConstants.LoginResult.UserNotFound:
                            TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_INVALID_USERNAME;
                            break;
                        case AppConstants.LoginResult.AccountLocked:
                            TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_ACCOUNT_LOCKED;
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
            }

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove(AppConstants.ID);
            HttpContext.Session.Remove(AppConstants.USERNAME);
            HttpContext.Session.Remove(AppConstants.AVATAR);
            HttpContext.Session.Remove(AppConstants.ROLE);

            return RedirectToPage(AppConstants.PAGE_HOME);
        }

        private void SetUserSession(UserDto user)
        {
            HttpContext.Session.SetString(AppConstants.ID, user.Id.ToString());
            HttpContext.Session.SetString(AppConstants.USERNAME, user.Username);
            HttpContext.Session.SetString(AppConstants.AVATAR, user.Avatar);
            byte[] roleIdBytes = BitConverter.GetBytes(user.RoleId);
            HttpContext.Session.Set(AppConstants.ROLE, roleIdBytes);
        }
    }
}
