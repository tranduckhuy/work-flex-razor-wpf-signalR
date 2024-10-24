using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;

namespace WorkFlex.Services
{
    public class ConversationService : IConversationService
    {
        private readonly AppDbContext _context;

        public ConversationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(ConversationDto, UserMessageDto)> GetConversation(string userId, Guid otherUserId)
        {
            var otherUser = await _context.Users.FindAsync(otherUserId) 
                ?? throw new ArgumentNullException(nameof(otherUserId), "User not found");
            
            var othersAccount = new UserMessageDto
            {
                Id = otherUserId,
                Name = userId == otherUserId.ToString() ? AppConstants.YOU : otherUser.FirstName + " " + otherUser.LastName,
                Avatar = otherUser.Avatar
            };

            var conversation = await _context.Conversations
                .FirstOrDefaultAsync(c => (c.UserOne == new Guid(userId) && c.UserTwo == otherUserId) ||
                                           (c.UserOne == otherUserId && c.UserTwo == new Guid(userId)));

            // Create a new conversation if one does not exist
            if (conversation == null)
            {
                conversation = new Conversation
                {
                    Id = Guid.NewGuid(),
                    UserOne = new Guid(userId),
                    UserTwo = otherUserId
                };

                _context.Conversations.Add(conversation);
                await _context.SaveChangesAsync();
            }

            return (AppMapper.Mapper.Map<ConversationDto>(conversation), othersAccount);
        }

        public async Task<List<ConversationReplyDto>> GetMessagesForConversation(Guid conversationId)
        {
            var messages = await (from r in _context.ConversationReplies
                                  where r.ConversationId == conversationId
                                  join u in _context.Users on r.UserId equals u.Id
                                  select new ConversationReplyDto
                                  {
                                      UserId = u.Id.ToString(),
                                      Name = u.FirstName + " " + u.LastName,
                                      Reply = r.Reply,
                                      Avatar = u.Avatar,
                                      Time = TimeZoneInfo.ConvertTimeFromUtc(r.Time, TimeZoneInfo.Local)
                                  }).ToListAsync();

            return messages.OrderBy(m => m.Time).ToList();
        }

		public async Task<List<UserMessageDto>> GetUserChats(string currentUserId)
		{
			var userId = new Guid(currentUserId);

			var query = from c in _context.Conversations
						join m in _context.ConversationReplies on c.Id equals m.ConversationId into messages
						where c.UserOne == userId || c.UserTwo == userId
						select new
						{
							OtherUserId = c.UserOne == userId ? c.UserTwo : c.UserOne,
							LastMessage = messages.OrderByDescending(msg => msg.Time).FirstOrDefault()
						};

			var latestMessages = await query.ToListAsync();

			var userIds = latestMessages.Select(x => x.OtherUserId).Distinct().ToList();

			var users = await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();

			var userMessageDtos = users.Select(u => {
				var messageInfo = latestMessages.FirstOrDefault(m => m.OtherUserId == u.Id);
				return new UserMessageDto
				{
					Id = u.Id,
					Name = u.Id != userId ? u.FirstName + " " + u.LastName : AppConstants.YOU,
					Avatar = u.Avatar,
					LastMessage = messageInfo?.LastMessage?.Reply,
					IsLastMessageCurrentUser = messageInfo?.LastMessage?.UserId == userId,
					LastMessageTime = messageInfo?.LastMessage?.Time
				};
			}).ToList();

			return userMessageDtos
		        .OrderByDescending(dto => dto.Id == userId)
		        .ThenByDescending(dto => dto.LastMessageTime)
		        .ToList();
		}
	}
}
