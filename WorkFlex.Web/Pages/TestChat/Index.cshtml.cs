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
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string OtherUserId { get; set; } = string.Empty;
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

                var conversation = await _conversationService.GetConversation(currentUserId, otherUserId);

                UserId = currentUserId.ToUpper();
                OtherUserId = otherUserId.ToString();
                ConversationId = conversation.Id.ToString();
                Messages = await _conversationService.GetMessagesForConversation(conversation.Id);

                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("Error getting conversation: {ex}", ex);
                return RedirectToPage("/Error/Error");
            }
        }
    }
}
