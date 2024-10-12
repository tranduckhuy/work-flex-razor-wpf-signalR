using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Chat
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
        public List<UserViewModel> Users { get; set; } = [];
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
                    TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_LOGIN_REQUIRED;
                    return RedirectToPage(AppConstants.PAGE_LOGIN);
                }

                if (otherUserId == Guid.Empty)
                {
                    otherUserId = new Guid(currentUserId);
                }

                var result = await _conversationService.GetConversation(currentUserId, otherUserId).ConfigureAwait(false);

                var currentUserAvatar = HttpContext.Session.GetString(AppConstants.AVATAR);

                CurrentUser = new UserViewModel
                {
                    Id = new Guid(currentUserId),
                    Username = HttpContext.Session.GetString(AppConstants.USERNAME) ?? string.Empty,
                    Avatar = string.IsNullOrEmpty(currentUserAvatar) ? AppConstants.DEFAULT_AVATAR : currentUserAvatar
                };

                OtherUser = new UserViewModel
                {
                    Id = otherUserId,
                    Username = result.Item2.Username,
                    Avatar = result.Item2.Avatar
                };

                var userChats = await _conversationService.GetUserChats(currentUserId).ConfigureAwait(false);

                Users.Add(CurrentUser);
                Users.AddRange(userChats);

                ConversationId = result.Item1.Id.ToString();
                Messages = await _conversationService.GetMessagesForConversation(result.Item1.Id);

                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("Error getting conversation: {ex}", ex);
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }
        }
    }
}
