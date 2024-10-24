    using Microsoft.AspNetCore.SignalR;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.SignalR.Hubs
{
    public sealed class ChatHub : Hub
    {
        private readonly AppDbContext _context;

        public ChatHub(AppDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(Guid userId, string message, Guid otherUserId, Guid conversationId)
        {
            var reply = new ConversationReply
            {
                Id = Guid.NewGuid(),
                Reply = message,
                UserId = userId,
                Time = DateTime.UtcNow,
                ConversationId = conversationId
            };

            await _context.ConversationReplies.AddAsync(reply);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(userId);

            await Clients.Groups(conversationId.ToString())
                .SendAsync("ReceiveMessage", userId.ToString().ToUpper(), user?.FirstName + " " + user?.LastName, message, user?.Avatar, reply.Time);
        }

        public async Task JoinConversation(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task LeaveConversation(string conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId);
        }
    }
}
