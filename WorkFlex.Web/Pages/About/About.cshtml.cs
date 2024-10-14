using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkFlex.Web.Pages.About
{
    public class AboutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
