using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Web.Pages.User
{
    public class ProfileModel : PageModel
    {

        private readonly ILogger<ProfileModel> _logger;
        private readonly IUserService _userService;

        public ProfileModel(ILogger<ProfileModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public new UserDto? User { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
			_logger.LogInformation("[OnGetAsync]: Start retrieving user by ID: {UserId}", userId);

			try
			{
				if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guidUserId))
				{
					_logger.LogWarning("[OnGetAsync]: Invalid user ID format.");
					return RedirectToPage("/Error/Error");
				}

				var userIdSession = HttpContext.Session.GetString("Id");

				if (userIdSession != null && Guid.TryParse(userIdSession, out var sessionId) && sessionId != guidUserId)
				{
					_logger.LogWarning("[OnGetAsync]: Unauthorized access attempt by user with ID: {SessionUserId}", userIdSession);
					return RedirectToPage("/Error/Error");
				}

				User = await _userService.GetByIdAsync(guidUserId);

				if (User == null)
				{
					_logger.LogWarning("[OnGetAsync]: User not found for ID: {UserId}", userId);
					return RedirectToPage("/Error/Error");
				}

				_logger.LogInformation("[OnGetAsync]: Successfully retrieved user with ID: {UserId}", userId);
				return Page();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[OnGetAsync]: Error retrieving user by ID: {UserId}", userId);
				return RedirectToPage("/Error/Error");
			}
		}
    }
}
