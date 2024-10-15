using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;

namespace WorkFlex.Web.Pages.Authen
{
    public class ResetModel : PageModel
    {
        private readonly IAuthenService _authenService;

        public ResetModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }
        public string ResetToken { get; private set; } = string.Empty;

        public IActionResult OnGet(string resetToken)
        {
            if (string.IsNullOrEmpty(resetToken))
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "Access denied. Please request a password reset email.";
                return RedirectToPage("Forgot");
            }

            var sessionToken = HttpContext.Session.GetString("ResetToken");
            var sessionExpiryTime = HttpContext.Session.GetString("ResetTokenExpiryTime");

            if (sessionToken != resetToken || string.IsNullOrEmpty(sessionExpiryTime) || DateTime.Parse(sessionExpiryTime) <= DateTime.UtcNow)
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "Invalid or expired token.";
                return RedirectToPage("Forgot");
            }

            ResetToken = resetToken;

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
            }
            else
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "The password change deadline for this time has expired. Please make another change password request.";
                return RedirectToPage("Reset");
            }
        }
    }
}