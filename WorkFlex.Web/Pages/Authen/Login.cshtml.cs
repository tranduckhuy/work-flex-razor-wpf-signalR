using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.ViewModels;
using WorkFlex.Web.Services;

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
            return Page();
        }

        public IActionResult OnPost(LoginVM loginVm)
        {
            if (!string.IsNullOrEmpty(loginVm.Email) && !string.IsNullOrEmpty(loginVm.Password))
            {
                var user = _authenService.checkLogin(loginVm);
                if (user != null)
                {
                    return RedirectToPage("/Home/Index");
                }
                return Content("Not found any user with this email!");
            }
            return Content("Email or Password is required!");
        }
    }
}
