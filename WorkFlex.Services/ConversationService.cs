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

            var conversations = await _context.Conversations
                .Where(c => c.UserOne == userId || c.UserTwo == userId)
                .Select(c => c.UserOne == userId ? c.UserTwo : c.UserOne)
                .ToListAsync();

            var userIds = conversations.Distinct().ToList();

            userIds.Remove(new Guid(currentUserId));

            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id)).ToListAsync();

            return users.Select(u => new UserMessageDto
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Avatar = u.Avatar
            }).ToList();
        }
    }
}
