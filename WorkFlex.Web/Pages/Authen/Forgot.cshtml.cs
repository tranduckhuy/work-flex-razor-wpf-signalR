using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;

namespace WorkFlex.Web.Pages.Authen
{
    public class ForgotModel : PageModel
    {
        private readonly IAuthenService _authenService;

        public ForgotModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        public IActionResult OnPost(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError(string.Empty, "Email is required.");
                return Page();
            }

            var result = _authenService.SendPasswordResetEmail(email, HttpContext.Session, HttpContext);
            if (_authenService.IsAccountLocked(email))
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_ACCOUNT_LOCKED;
                return RedirectToPage("Forgot");
            }
            if (result)
            {
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = "A reset password request has been sent to your email.";
                return RedirectToPage("Login");
            }
            else
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "Failed to send email. Please try again.";
                return RedirectToPage("Forgot");
            }
        }
    }
}