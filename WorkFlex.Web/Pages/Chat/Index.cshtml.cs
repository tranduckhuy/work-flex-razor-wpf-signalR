using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
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
        public List<UserMessageVM> Users { get; set; } = [];
        public UserMessageVM CurrentUser { get; set; } = null!;
        public UserMessageVM OtherUser { get; set; } = null!;
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

                CurrentUser = new UserMessageVM
                {
                    Id = new Guid(currentUserId),
                    Name = AppConstants.YOU,
                    Avatar = string.IsNullOrEmpty(currentUserAvatar) ? AppConstants.DEFAULT_AVATAR : currentUserAvatar
                };

                OtherUser = new UserMessageVM
                {
                    Id = otherUserId,
                    Name = result.Item2.Name,
                    Avatar = result.Item2.Avatar
                };

                var userChatsDto = await _conversationService.GetUserChats(currentUserId).ConfigureAwait(false);
                var userChats = AppMapper.Mapper.Map<List<UserMessageVM>>(userChatsDto);

                Users.Add(CurrentUser);
                Users.AddRange(userChats);

                ConversationId = result.Item1.Id.ToString();
                var messagesDto = await _conversationService.GetMessagesForConversation(result.Item1.Id);
                Messages = AppMapper.Mapper.Map<List<ConversationReplyViewModel>>(messagesDto);

                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("Error getting conversation: {ex}", ex);
                return RedirectToPage(AppConstants.PAGE_ERROR);
            }
        }
    }
}
