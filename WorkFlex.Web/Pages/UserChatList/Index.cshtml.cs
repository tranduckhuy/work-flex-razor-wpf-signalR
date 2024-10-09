using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Web.Pages.UserChatList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<UserChat> UserChats { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.User.Identity == null || !HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/TestLogin/Index");
            }

            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (currentUserId == null)
            {
                return RedirectToPage("/Error");
            }

            await GetUserChats(currentUserId);

            return Page();
        }

        private async Task GetUserChats(string currentUserId)
        {
            var userId = new Guid(currentUserId);

            var conversations = await _context.Conversations
                .Where(c => c.UserOne == userId || c.UserTwo == userId)
                .Select(c => c.UserOne == userId ? c.UserTwo : c.UserOne)
                .ToListAsync();

            var userIds = conversations.Distinct().ToList();

            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    Avatar = string.IsNullOrEmpty(u.Avatar)
                            ? "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg"
                            : u.Avatar
                })
                .ToListAsync();

            UserChats = users.Select(u => new UserChat
            {
                Id = u.Id,
                Username = u.Username,
                Avatar = u.Avatar
            }).ToList();
        }
    }

    public class UserChat
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
