using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.ViewModels;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Untils.Helper.Interface;

namespace WorkFlex.Web.Pages.Authen
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IAuthenService _authenService;
        private readonly IAddressHelper _addressHelper;

        public LoginModel(ILogger<LoginModel> logger, IAuthenService authenService, IAddressHelper addressHelper)
        {
            _logger = logger;
            _authenService = authenService;
            _addressHelper = addressHelper;
        }

        public LoginVM LoginVM { get; set; } = null!;

        public IActionResult OnGet()
        {
            var username = HttpContext.Session.GetString(AppConstants.USERNAME);
            if (username == null)
                return Page();
            return RedirectToPage(AppConstants.PAGE_HOME);
        }

        public IActionResult OnPost(LoginVM loginVm)
        {
            _logger.LogInformation("[OnPost]: Controller - Start doing authentication for user");

            var usernameSession = HttpContext.Session.GetString(AppConstants.USERNAME);
            _logger.LogDebug("[OnPost]: Controller - User's old session: {usernameSession}", usernameSession);
            if (!string.IsNullOrEmpty(usernameSession) && usernameSession == loginVm.Username)
            {
                return RedirectToPage(AppConstants.PAGE_HOME);
            }

            if (usernameSession == null || usernameSession != loginVm.Username)
            {
                try
                {
                    var loginDto = _authenService.CheckLogin(loginVm);
                    _logger.LogDebug("[OnPost]: Controller - Authentication information after checking: {loginDto}", loginDto);
                    switch (loginDto!.Result)
                    {
                        case AppConstants.LoginResult.Success:
                            if (loginDto.User != null)
                            {
                                SetUserSession(loginDto.User);
                                _logger.LogDebug("[OnPost]: Controller - User's information after checking: {user}", loginDto.User);
                                _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with status: Authentiaction Success!");
                                if (loginDto.User.RoleId == 1)
                                    return RedirectToPage(AppConstants.PAGE_DASHBOARD);
                                return RedirectToPage(AppConstants.PAGE_HOME);
                            }
                            break;
                        case AppConstants.LoginResult.UserNotFound:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_USERNAME;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with status: {message}", AppConstants.MESSAGE_INVALID_USERNAME);
                            break;
                        case AppConstants.LoginResult.InvalidPassword:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_PASSWORD;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with status: {message}", AppConstants.MESSAGE_INVALID_PASSWORD);
                            break;
                        case AppConstants.LoginResult.AccountLocked:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_ACCOUNT_LOCKED;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with status: {message}", AppConstants.MESSAGE_ACCOUNT_LOCKED);
                            break;
                        default:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with status: {message}", AppConstants.MESSAGE_FAILED);
                            break;
                    }
                } 
                catch (Exception ex) 
                {
                    // Remove all session if got error while logging
                    OnGetLogout();
                    TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                    _logger.LogError("[OnPost]: Controller - End doing authentication for user with error: {ex}", ex.StackTrace);
                    return Page();
                }
            }

            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove(AppConstants.ID);
            HttpContext.Session.Remove(AppConstants.USERNAME);
            HttpContext.Session.Remove(AppConstants.NAME);
            HttpContext.Session.Remove(AppConstants.AVATAR);
            HttpContext.Session.Remove(AppConstants.LOCATION);
            HttpContext.Session.Remove(AppConstants.ROLE);

            return RedirectToPage(AppConstants.PAGE_HOME);
        }

		public IActionResult OnGetActivate(string email, string token)
		{
			_logger.LogInformation("[OnGetActivate]: Controller - Start activating account for user {email}", email);

			try
			{
				// Call the ActivateAccount method from service
				bool isActivated = _authenService.ActivateAccount(email, token, HttpContext.Session);

				if (!isActivated)
				{
					TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_ACTIVATION_LINK;
					_logger.LogWarning("[OnGetActivate]: Controller - Activation failed, invalid token or user not found for {email}", email);
					return Page();
				}

				TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_ACIVATE_ACCOUNT_SUCCESS;
				_logger.LogInformation("[OnGetActivate]: Controller - Account activated for user {email}", email);
			}
			catch (Exception ex)
			{
				TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = "An error occurred during activation.";
				_logger.LogError("[OnGetActivate]: Controller - Error activating account for user {email}. Error: {ex}", email, ex.StackTrace);
				return Page();
			}

			return Page();
		}

		private void SetUserSession(UserDto user)
        {
            HttpContext.Session.SetString(AppConstants.ID, user.Id.ToString());
            HttpContext.Session.SetString(AppConstants.USERNAME, user.Username);
            HttpContext.Session.SetString(AppConstants.NAME, user.FirstName + " " + user.LastName);
            HttpContext.Session.SetString(AppConstants.AVATAR, user.Avatar);
            HttpContext.Session.SetString(AppConstants.LOCATION, _addressHelper.ExtractCityProvince(user.Location));
            byte[] roleIdBytes = BitConverter.GetBytes(user.RoleId);
            HttpContext.Session.Set(AppConstants.ROLE, roleIdBytes);
        }
    }
}
