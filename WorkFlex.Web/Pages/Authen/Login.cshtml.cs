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
            var username = HttpContext.Session.GetString("Username");
            if (username == null) 
                return Page();
            return RedirectToPage("/Home/Index");
            
        }

        public IActionResult OnPost(LoginVM loginVm)
        {
            var usernameSession = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(usernameSession) && usernameSession == loginVm.Username)
            {
                return RedirectToPage("/Home/Index");
            }

            if (usernameSession == null || usernameSession != loginVm.Username)
            {
                var loginDto = _authenService.checkLogin(loginVm);
                switch (loginDto!.Result)
                {
                    case AppConstants.LoginResult.Success:
                        if (loginDto.User != null)
                        {
                            SetUserSession(loginDto.User);
                            return RedirectToPage("/Home/Index");
                        }
                        break;
                    case AppConstants.LoginResult.InvalidPassword:
                        TempData["Message"] = AppConstants.MESSAGE_INVALID_PASSWORD;
                        break;
                    case AppConstants.LoginResult.UserNotFound:
                        TempData["Message"] = AppConstants.MESSAGE_INVALID_USERNAME;
                        break;
                    case AppConstants.LoginResult.AccountLocked:
                        TempData["Message"] = AppConstants.MESSAGE_ACCOUNT_LOCKED;
                        break;
                    default:
                        TempData["Message"] = AppConstants.MESSAGE_LOGIN_FAILED;
                        break;
                }
            }

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Avatar");
            HttpContext.Session.Remove("Role");

            return RedirectToPage("/Home/Index");
        }

        private void SetUserSession(UserDTO user)
        {
            HttpContext.Session.SetString("Id", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Avatar", user.Avatar);
            byte[] roleIdBytes = BitConverter.GetBytes(user.RoleId);
            HttpContext.Session.Set("Role", roleIdBytes);
        }
    }
}
