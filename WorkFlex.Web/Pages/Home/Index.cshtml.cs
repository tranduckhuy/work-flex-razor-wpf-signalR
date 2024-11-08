using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Web.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService; // Service for user operations

        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task OnGet()
        {
            _logger.LogInformation("Home page visited");

            // Get userId from session
            var userIdString = HttpContext.Session.GetString(AppConstants.ID);
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                // Get user information from DB
                var user = await _userService.GetByIdAsync(userId);
                if (user != null)
                {
                    // Set session of user
                    SetUserSession(user);
                    _logger.LogInformation("User session updated for user ID: {UserId}", userId);
                }
                else
                {
                    _logger.LogWarning("User not found with ID: {UserId}", userId);
                }
            }
            else
            {
                _logger.LogWarning("User ID not found in session");
            }
        }

        private void SetUserSession(UserDto user)
        {
            HttpContext.Session.SetString(AppConstants.ID, user.Id.ToString());
            HttpContext.Session.SetString(AppConstants.SUBSCRIPTION, user.SubscriptionType.ToString());
            byte[] roleIdBytes = BitConverter.GetBytes(user.RoleId);
            HttpContext.Session.Set(AppConstants.ROLE, roleIdBytes);
        }
    }
}
