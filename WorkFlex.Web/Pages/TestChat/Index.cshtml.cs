using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Web.Pages.TestChat
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<ConversationReplyViewModel> Messages { get; set; } = [];
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string OtherUserId { get; set; } = string.Empty;
        public string ConversationId { get; set; } = string.Empty;

        public async Task<IActionResult> OnGet(Guid otherUserId)
        {
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!HttpContext.User.Identity!.IsAuthenticated || string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToPage("/TestLogin/Index");
            }

            if (otherUserId == Guid.Empty)
            {
                return RedirectToPage("/Error/Error");
            }

            var otherUser = await _context.Users.FindAsync(otherUserId);

            if (otherUser == null)
            {
                return RedirectToPage("/Error/Error");
            }

            var conversation = await GetConversation(currentUserId, otherUserId);

            UserId = currentUserId.ToUpper();
            OtherUserId = otherUserId.ToString();
            ConversationId = conversation.Id.ToString();
            Messages = await GetMessagesForConversation(conversation.Id);

            return Page();
        }

        private async Task<Conversation> GetConversation(string userId, Guid otherUserId)
        {
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

            return conversation;
        }

        private async Task<List<ConversationReplyViewModel>> GetMessagesForConversation(Guid conversationId)
        {
            var messages = await (from r in _context.ConversationReplies
                                  where r.ConversationId == conversationId
                                  join u in _context.Users on r.UserId equals u.Id
                                  select new ConversationReplyViewModel
                                  {
                                      UserId = u.Id.ToString(),
                                      UserName = u.Username,
                                      Reply = r.Reply,
                                      Time = TimeZoneInfo.ConvertTimeFromUtc(r.Time, TimeZoneInfo.Local)
                                  }).ToListAsync();

            return messages.OrderBy(m => m.Time).ToList();
        }
    }

    public class ConversationReplyViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Reply { get; set; } = string.Empty;
        public DateTime Time { get; set; }
    }
}
