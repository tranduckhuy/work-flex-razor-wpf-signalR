using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Interface
{
    public interface IConversationService
    {
        Task<List<ConversationReplyDto>> GetMessagesForConversation(Guid conversationId);

        Task<(ConversationDto, UserMessageDto)> GetConversation(string userId, Guid otherUserId);

        Task<List<UserMessageDto>> GetUserChats(string currentUserId);
    }
}
