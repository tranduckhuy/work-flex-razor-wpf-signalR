using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.TestUserList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<UserMessageVM> Users { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);

            if (string.IsNullOrEmpty(currentUserId))
            {
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

            Users = await _context.Users
                .Where(u => u.Id != new Guid(currentUserId))
                .Select(u => new UserMessageVM
                {
                    Name = u.FirstName + " " + u.LastName,
                    Id = u.Id,
                    Avatar = string.IsNullOrEmpty(u.Avatar)
                            ? AppConstants.DEFAULT_AVATAR
                            : u.Avatar
                }).ToListAsync();

            return Page();
        }
    }
}
