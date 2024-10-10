using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.UserChatList
{
    public class IndexModel : PageModel
    {
        private readonly IConversationService _conversationService;

        public IndexModel(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        public List<UserViewModel> UserChats { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var currentUserId = HttpContext.Session.GetString(AppConstants.ID);

            if (string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToPage(AppConstants.PAGE_LOGIN);
            }

           UserChats = await _conversationService.GetUserChats(currentUserId);

            return Page();
        }
    }
}
