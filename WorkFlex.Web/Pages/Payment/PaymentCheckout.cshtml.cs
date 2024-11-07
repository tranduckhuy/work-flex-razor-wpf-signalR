using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkFlex.Web.Pages.Payment
{
    public class PaymentCheckoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
