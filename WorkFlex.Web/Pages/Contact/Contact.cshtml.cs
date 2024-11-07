using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkFlex.Web.Pages.Contact
{
    public class ContactModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
