using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services.Interface
{
    public interface IConversationService
    {
        Task<List<ConversationReplyViewModel>> GetMessagesForConversation(Guid conversationId);
        Task<ConversationDto> GetConversation(string userId, Guid otherUserId);
        Task<List<UserViewModel>> GetUserChats(string currentUserId);
    }
}
