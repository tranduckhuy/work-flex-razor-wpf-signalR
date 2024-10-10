using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.TestChat
{
    public class IndexModel : PageModel
    {
        private readonly IConversationService _conversationService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IConversationService conversationService, ILogger<IndexModel> logger)
        {
            _conversationService = conversationService;
            _logger = logger;
        }

        public List<ConversationReplyViewModel> Messages { get; set; } = [];
        public UserViewModel CurrentUser { get; set; } = null!;
        public UserViewModel OtherUser { get; set; } = null!;
        public string ConversationId { get; set; } = string.Empty;

        public async Task<IActionResult> OnGet(Guid otherUserId)
        {
            try
            {
                var currentUserId = HttpContext.Session.GetString(AppConstants.ID);

                if (string.IsNullOrEmpty(currentUserId))
                {
                    return RedirectToPage(AppConstants.PAGE_LOGIN);
                }

                var result = await _conversationService.GetConversation(currentUserId, otherUserId);

                CurrentUser = new UserViewModel
                {
                    Id = new Guid(currentUserId),
                    Username = HttpContext.Session.GetString(AppConstants.USERNAME) ?? string.Empty,
                    Avatar = HttpContext.Session.GetString(AppConstants.AVATAR) ?? string.Empty
                };

                OtherUser = new UserViewModel
                {
                    Id = otherUserId,
                    Username = result.Item2.Username
                };

                ConversationId = result.Item1.Id.ToString();
                Messages = await _conversationService.GetMessagesForConversation(result.Item1.Id);

                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("Error getting conversation: {ex}", ex);
                return RedirectToPage("/Error/Error");
            }
        }
    }
}
