using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkFlex.Web.Pages.Dashboard
{
    public class DashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
