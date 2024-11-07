using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;

namespace WorkFlex.Web.Pages.Authen
{
    public class ForgotModel : PageModel
    {
        private readonly IAuthenService _authenService;

        public ForgotModel(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        public async Task<IActionResult> OnPost(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError(string.Empty, "Email is required.");
                return Page();
            }

            var result = await _authenService.SendMailResetEmailAsync(email, HttpContext.Session, HttpContext);
            if (await _authenService.IsAccountLockedAsync(email))
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