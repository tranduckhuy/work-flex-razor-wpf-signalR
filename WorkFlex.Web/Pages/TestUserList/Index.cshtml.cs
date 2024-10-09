using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Web.Pages.TestUserList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<UserViewModel> Users { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToPage("/Error/Error");
            }

            Users = await _context.Users
                .Where(u => u.Id != new Guid(userId))
                .Select(u => new UserViewModel
                {
                    Username = u.Username,
                    UserId = u.Id.ToString(),
                    Avatar = u.Avatar
                }).ToListAsync();

            return Page();
        }
    }

    public class UserViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
    }
}
