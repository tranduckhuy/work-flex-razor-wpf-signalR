using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.Constants;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services
{
    public class ConversationService : IConversationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ConversationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(ConversationDto, UserViewModel)> GetConversation(string userId, Guid otherUserId)
        {
            var otherUser = await _context.Users.FindAsync(otherUserId) 
                ?? throw new ArgumentNullException(nameof(otherUserId), "User not found");
            
            var othersAccount = new UserViewModel
            {
                Id = otherUserId,
                Username = otherUser.FirstName + " " + otherUser.LastName,
                Avatar = string.IsNullOrEmpty(otherUser.Avatar)
                         ? AppConstants.DEFAULT_AVATAR
                         : otherUser.Avatar
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

            return (_mapper.Map<ConversationDto>(conversation), othersAccount);
        }

        public async Task<List<ConversationReplyViewModel>> GetMessagesForConversation(Guid conversationId)
        {
            var messages = await (from r in _context.ConversationReplies
                                  where r.ConversationId == conversationId
                                  join u in _context.Users on r.UserId equals u.Id
                                  select new ConversationReplyViewModel
                                  {
                                      UserId = u.Id.ToString(),
                                      UserName = u.FirstName + " " + u.LastName,
                                      Reply = r.Reply,
                                      Avatar = string.IsNullOrEmpty(u.Avatar)
                                              ? AppConstants.DEFAULT_AVATAR
                                              : u.Avatar,
                                      Time = TimeZoneInfo.ConvertTimeFromUtc(r.Time, TimeZoneInfo.Local)
                                  }).ToListAsync();

            return messages.OrderBy(m => m.Time).ToList();
        }

        public async Task<List<UserViewModel>> GetUserChats(string currentUserId)
        {
            var userId = new Guid(currentUserId);

            var conversations = await _context.Conversations
                .Where(c => c.UserOne == userId || c.UserTwo == userId)
                .Select(c => c.UserOne == userId ? c.UserTwo : c.UserOne)
                .ToListAsync();

            var userIds = conversations.Distinct().ToList();

            userIds.Remove(new Guid(currentUserId));

            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    Avatar = string.IsNullOrEmpty(u.Avatar)
                            ? AppConstants.DEFAULT_AVATAR
                            : u.Avatar
                })
                .ToListAsync();

            return users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Username = u.FirstName + " " + u.LastName,
                Avatar = u.Avatar
            }).ToList();
        }
    }
}
