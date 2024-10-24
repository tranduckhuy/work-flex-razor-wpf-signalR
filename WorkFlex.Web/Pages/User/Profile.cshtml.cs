using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.User
{
    public class ProfileModel : PageModel
    {
		private readonly ILogger<ProfileModel> _logger;
		private readonly IUserService _userService;
        private readonly IAddressHelper _addressHelper;

        public ProfileModel(ILogger<ProfileModel> logger, IUserService userService, IAddressHelper addressHelper)
		{
			_logger = logger;
			_userService = userService;
            _addressHelper = addressHelper;
		}

		public UserDto? UserDto { get; set; }

		public ProfileVM ProfileVM { get; set; } = null!;

		public bool IsYourProfile { get; set; } = true;

		public async Task<IActionResult> OnGetAsync(string userId)
		{
			_logger.LogInformation("[OnGetAsync]: Controller - Start retrieving user by ID: {UserId}", userId);

			try
			{
				if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guidUserId))
				{
					_logger.LogWarning("[OnGetAsync]: Controller - Invalid user ID format.");
					return RedirectToPage(AppConstants.PAGE_ERROR);
				}

                UserDto = await _userService.GetByIdAsync(guidUserId);
				if (UserDto == null)
				{
					_logger.LogWarning("[OnGetAsync]: Controller - User not found for ID: {UserId}", userId);
					return RedirectToPage(AppConstants.PAGE_ERROR);
				}

                var userIdSession = HttpContext.Session.GetString("Id");
                if (userIdSession != null && Guid.TryParse(userIdSession, out var sessionId) && sessionId != guidUserId)
                {
                    IsYourProfile = false;
                    return Page();
                }

                _logger.LogInformation("[OnGetAsync]: Controller - Successfully retrieved user with ID: {UserId}", userId);
				return Page();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[OnGetAsync]: Controller - Error retrieving user by ID: {UserId}", userId);
				return RedirectToPage(AppConstants.PAGE_ERROR);
			}
		}

        public async Task OnPostAsync(string formType, ProfileVM profileVM)
        {
            if (formType == "profileForm")
            {
                await HandleProfileUpdateAsync(profileVM);
            }
            else if (formType == "passwordForm")
            {
                await HandleChangePasswordAsync(profileVM);
            }
        }

        private async Task<IActionResult> HandleProfileUpdateAsync(ProfileVM profileVM)
        {
            _logger.LogInformation("[HandleProfileUpdateAsync]: Controller - Start updating profile for user: {UserId}", UserDto?.Id);
            try
            {
                var updateResult = await _userService.UpdateUserProfileAsync(AppMapper.Mapper.Map<ProfileDto>(profileVM));
                if (!updateResult)
                {
                    TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_UPDATE_PROFILE_FAILED;
                    await SetUserAsync(profileVM.Id);
                    return Page();
                }

                _logger.LogInformation("[HandleProfileUpdateAsync]: Controller - Profile updated successfully.");
                TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_UPDATE_PROFILE_SUCCESSFULLY;
                await SetUserAsync(profileVM.Id);
                return Page();
            } catch (Exception ex)
            {
                _logger.LogError("[HandleProfileUpdateAsync]: Controller - End updating profile for user: {UserId} with error: {ex}", profileVM.Id, ex.StackTrace);
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                await SetUserAsync(profileVM.Id);
                return Page();
            }
        }

        private async Task<IActionResult> HandleChangePasswordAsync(ProfileVM profileVM)
        {
            _logger.LogInformation("[HandleChangePasswordAsync]: Controller - Start changing password for user: {UserId}", profileVM.Id);

            try
            {
                var passwordChangeResult = await _userService.ChangePasswordAsync(AppMapper.Mapper.Map<ProfileDto>(profileVM));
                switch (passwordChangeResult)
                {
                    case AppConstants.ProfileResult.Success:
                        TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_CHANGE_PASSWORD_SUCCESSFULLY;
                        await SetUserAsync(profileVM.Id);
                        return Page();
                    case AppConstants.ProfileResult.UserNotFound:
                        TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_USER_NOT_FOUND;
                        await SetUserAsync(profileVM.Id);
                        return Page();
                    case AppConstants.ProfileResult.InvalidPassword:
                        TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_OLD_PASSWORD;
                        await SetUserAsync(profileVM.Id);
                        return Page();
                    case AppConstants.ProfileResult.PasswordNotMatch:
                        TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_NOT_MATCH_PASSWORD;
                        await SetUserAsync(profileVM.Id);
                        return Page();
                    default:
                        TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                        await SetUserAsync(profileVM.Id);
                        return Page();
                }
            } catch (Exception ex) 
            {
                _logger.LogError("[HandleChangePasswordAsync]: Controller - End changing password for user: {UserId} with error: {ex}", profileVM.Id, ex.StackTrace);
                TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                await SetUserAsync(profileVM.Id);
                return Page();
            }
        }

        private async Task SetUserAsync(Guid userId)
        {
            UserDto = await _userService.GetByIdAsync(userId);

            if (UserDto == null)
            {
                _logger.LogWarning("[SetUserAsync]: Controller - User not found for ID: {UserId}", userId);
                RedirectToErrorPage();
                return;
            }

            SetUserSession(UserDto);
        }

        private void SetUserSession(UserDto user)
        {
            HttpContext.Session.SetString(AppConstants.NAME, $"{user.FirstName} {user.LastName}");
            HttpContext.Session.SetString(AppConstants.AVATAR, user.Avatar ?? string.Empty);
            HttpContext.Session.SetString(AppConstants.LOCATION, _addressHelper.ExtractCityProvince(user.Location ?? string.Empty));
        }

        private void RedirectToErrorPage()
        {
            RedirectToPage(AppConstants.PAGE_ERROR);
        }
    }
}
