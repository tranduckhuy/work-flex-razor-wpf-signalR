using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkFlex.Web.Pages.User
{
    public class ProfileModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
