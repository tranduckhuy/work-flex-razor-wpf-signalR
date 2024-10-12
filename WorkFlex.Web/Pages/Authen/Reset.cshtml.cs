using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;

namespace WorkFlex.Web.Pages.Authen
{
    public class ResetModel : PageModel
    {
        private readonly IAuthenService _authenService;

        public ResetModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        public IActionResult OnGet()
        {
            var token = HttpContext.Session.GetString("ResetToken");
            if (string.IsNullOrEmpty(token))
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "Access denied. Please request a password reset email.";
                return RedirectToPage("Forgot"); 
            }

            return Page(); 
        }

        public IActionResult OnPost(string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "Passwords do not match!";
                return RedirectToPage("Reset");
            }

            var result = _authenService.ChangePassword(newPassword, HttpContext.Session);
            if (result)
            {
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = "Password reset successfully. You can now log in.";
                return RedirectToPage("Login");
            } else
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "The password change deadline for this time has expired, please send another email!!";
                return RedirectToPage("Reset");
            }
        }
    }
}