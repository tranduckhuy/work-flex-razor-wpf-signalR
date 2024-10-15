using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.ViewModels;

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

        public LoginReqVM LoginVM { get; set; } = null!;

        public IActionResult OnGet()
        {
            var username = HttpContext.Session.GetString(AppConstants.USERNAME);
            if (username == null)
                return Page();
            return RedirectToPage(AppConstants.PAGE_HOME);
        }

        public IActionResult OnPost(LoginReqVM loginVm)
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
                    var loginDto = _authenService.CheckLogin(AppMapper.Mapper.Map<LoginReqDto>(loginVm));
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
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with message: {message}", AppConstants.MESSAGE_INVALID_USERNAME);
                            break;
                        case AppConstants.LoginResult.InvalidPassword:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_PASSWORD;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with message: {message}", AppConstants.MESSAGE_INVALID_PASSWORD);
                            break;
                        case AppConstants.LoginResult.AccountLocked:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_ACCOUNT_LOCKED;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with message: {message}", AppConstants.MESSAGE_ACCOUNT_LOCKED);
                            break;
						case AppConstants.LoginResult.AccountInactive:
							TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_ACCOUNT_INACTIVE;
							_logger.LogInformation("[OnPost]: Controller - End doing authentication for user with message: {message}", AppConstants.MESSAGE_ACCOUNT_INACTIVE);
							break;
						default:
                            TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                            _logger.LogInformation("[OnPost]: Controller - End doing authentication for user with message: {message}", AppConstants.MESSAGE_FAILED);
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
				AppConstants.ActivateResult activateResult = _authenService.ActivateAccount(email, token, HttpContext.Session, HttpContext);
                switch (activateResult) 
                { 
                    case AppConstants.ActivateResult.Success:
                        TempData[AppConstants.TEMP_DATA_SUCCESS_MESSAGE] = AppConstants.MESSAGE_ACIVATE_ACCOUNT_SUCCESS;
						_logger.LogInformation("[OnGetActivate]: Controller - End activate account for user {email} with message: {message}", email, AppConstants.MESSAGE_ACIVATE_ACCOUNT_SUCCESS);
						return Page();
                    case AppConstants.ActivateResult.InvalidToken:
						TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_INVALID_ACTIVATION_LINK;
						_logger.LogInformation("[OnGetActivate]: Controller - End activate account for user {email} with message: {message}", email, AppConstants.MESSAGE_INVALID_ACTIVATION_LINK);
						return Page();
                    case AppConstants.ActivateResult.TokenExpired:
						TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_ACTIVATE_TOKEN_EXPIRED;
						_logger.LogInformation("[OnGetActivate]: Controller - End activate account for user {email} with message: {message}", email, AppConstants.MESSAGE_ACTIVATE_TOKEN_EXPIRED);
						return Page();
                    case AppConstants.ActivateResult.Error:
                        TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
						_logger.LogInformation("[OnGetActivate]: Controller - End activate account for user {email} with message: {message}", email, AppConstants.MESSAGE_FAILED);
						return Page();
                    default:
						TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
                        _logger.LogInformation("[OnGetActivate]: Controller - End activate account for user {email} with message: {message}", email, AppConstants.MESSAGE_FAILED);
						return Page();
				}
			}
			catch (Exception ex)
			{
				TempData[AppConstants.TEMP_DATA_FAILED_MESSAGE] = AppConstants.MESSAGE_FAILED;
				_logger.LogError("[OnGetActivate]: Controller - Error activating account for user {email} with error: {ex}", email, ex.StackTrace);
				return Page();
			}
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
