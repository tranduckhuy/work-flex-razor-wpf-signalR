using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Utils.Helper.Interface;
using WorkFlex.Infrastructure.Utils.Mail;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;
using static WorkFlex.Infrastructure.Constants.AppConstants;

using Profile = WorkFlex.Domain.Entities.Profile;

namespace WorkFlex.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly ILogger<AuthenService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IEmailHelper _emailHelper;
		private readonly SendMailUtil _sendMailUtil;

        private const string RESET_TOKEN = "ResetToken";
        private const string RESET_TOKEN_EXPIRY_TIME = "ResetTokenExpiryTime";
        private const string RESET_TOKEN_USER_EMAIL = "ResetTokenUserEmail";

        private const string ACTIVATE_TOKEN = "ActivateToken";
        private const string ACTIVATE_TOKEN_EXPIRY_TIME = "ActivateTokenExpiryTime";

		public AuthenService(ILogger<AuthenService> logger, IUserRepository userRepository, IProfileRepository profileRepository, IEmailHelper emailHelper, SendMailUtil sendMailUtil)
        {
            _logger = logger;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _emailHelper = emailHelper;
            _sendMailUtil = sendMailUtil;
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _userRepository.IsEmailExistAsync(email);
        }

        public async Task<bool> IsAccountLockedAsync(string email)
        {
            return await _userRepository.IsAccountLockedAsync(email);
        }

        public async Task<bool> SendMailResetEmailAsync(string userEmail, ISession session, HttpContext httpContext)
        {
            try
            {
				var user = await _userRepository.GetUserByEmailAsync(userEmail);
				if (user == null)
				{
					return false; // User not found
				}

				var resetToken = Guid.NewGuid().ToString();
				var resetTokenExpiryTime = DateTime.UtcNow.AddMinutes(5);

				// Save the token and expiry time in the session
				session.SetString(RESET_TOKEN, resetToken);
				session.SetString(RESET_TOKEN_EXPIRY_TIME, resetTokenExpiryTime.ToString());
				session.SetString(RESET_TOKEN_USER_EMAIL, userEmail);

				// Construct the reset link for the email
				var resetLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Authen/Reset/{resetToken}";
				var mailContent = new MailContent
				{
					To = userEmail,
					Subject = "Reset Password",
					Body = _emailHelper.RenderBodyResetPassword(resetLink)
				};

				_ = _sendMailUtil.SendMail(mailContent); // Send the email asynchronously

				return true; // Email successfully sent
			} catch
            {
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(string newPassword, ISession session)
        {
            try
            {
				var sessionToken = session.GetString(RESET_TOKEN);
				var sessionTokenExpiryTime = session.GetString(RESET_TOKEN_EXPIRY_TIME);
				var sessionUserEmail = session.GetString(RESET_TOKEN_USER_EMAIL);
				var user = await _userRepository.GetUserByEmailAsync(sessionUserEmail!);

				// Validate session: check token existence, expiry time, and user email
				if (string.IsNullOrEmpty(sessionToken) || 
                    string.IsNullOrEmpty(sessionTokenExpiryTime) || 
                    string.IsNullOrEmpty(sessionUserEmail) ||
                    user == null ||
					DateTime.Parse(sessionTokenExpiryTime!) <= DateTime.UtcNow)
				{
					return false; // Token is invalid, expired, user email is empty or user is not found
				}

				// Hash the new password and update the user
				user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
				await _userRepository.UpdateUserAsync(user); // Save changes

				// Remove token and other session details
				session.Remove(RESET_TOKEN);
				session.Remove(RESET_TOKEN_EXPIRY_TIME);
				session.Remove(RESET_TOKEN_USER_EMAIL);

				return true; // Password successfully reset
			} catch
            {
                return false;
            }
        }

        public async Task<LoginResDto?> CheckLoginAsync(LoginReqDto loginReqDto)
        {
            _logger.LogInformation("[checkLogin]: Service - Start checking user's authenticate information");
            var loginDto = new LoginResDto();
            try
            {
                User? user;
                // If user using email for log in then check email
                if (IsEmailFormat(loginReqDto.Username))
                {
                    user = await _userRepository.GetUserByEmailAsync(loginReqDto.Username);
                }
                // If user using username for log in then check username
                else
                {
                    user = await _userRepository.GetUserByUsernameAsync(loginReqDto.Username);
                }

                if (user != null)
                {
                    _logger.LogDebug("[checkLogin]: Service - User's information: {user}", user);
                    // If user's account is locked then notify and not allow user access into the system
                    if (user.IsLock)
                    {
                        loginDto.Result = LoginResult.AccountLocked;
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: User's account is locked.");
                        return loginDto;
                    }

                    if (!user.IsActive)
                    {
						loginDto.Result = LoginResult.AccountInactive;
						_logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: User's account is not active.");
						return loginDto;
					}

                    // Check password user input that true or not
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginReqDto.Password, user.Password);
                    if (isValidPassword)
                    {
                        var userDto = AppMapper.Mapper.Map<UserDto>(user);
                        _logger.LogDebug("[checkLogin]: Service - User's information after mapping: {userDto}", userDto);
                        loginDto.User = userDto;
                        loginDto.Result = LoginResult.Success;
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: Login successfully.");
                    }
                    else
                    {
                        loginDto.Result = LoginResult.InvalidPassword;
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: Incorrect password.");
                    }

                    return loginDto;
                }
                else
                {
                    loginDto.Result = LoginResult.UserNotFound;
                    _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: User not found.");
                    return loginDto;
                }
            }
            catch (Exception ex)
            {
                loginDto.Result = LoginResult.Error;
                _logger.LogError("[checkLogin]: Service - End checking user's authenticate information with error: {ex}", ex.StackTrace);
                return loginDto;
            }
        }

        public async Task<RegisterResult> AddUserAsync(RegisterDto registerDto, ISession session, HttpContext httpContext)
        {
            _logger.LogInformation("[addUser]: Service - Start add a new user");
            RegisterResult result;
            try
            {
                // Check Email that exist in DB or not
                var existingUser = await _userRepository.GetUserByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    result = RegisterResult.EmailExist;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: Email exist.");
                    return result;
                }

                // Check Password and RePassword must be matching
                if (registerDto.Password != registerDto.RePassword)
                {
                    result = RegisterResult.NotMatchPassword;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: New password and re-peat password not match.");
                    return result;
                }

                // if all condition is valid then create a new User
                var user = new User
                {
                    Username = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    Avatar = DEFAULT_AVATAR,
                    BackgroundImg = DEFAULT_BGR_IMG,
                    DateOfBirth = DateTime.MinValue,
                    IsActive = false,
                    IsLock = false,
                    RoleId = 3,
                    CreatedAt = DateTime.UtcNow
                };
                _logger.LogDebug("[addUser]: Service - User's information: {user}", user);

                var profile = new Profile
                {
                    UserId = user.Id,
                    Headline = "",
                    Summary = "",
                    Website = "",
                };

                // Save user to DB
                await _userRepository.AddUserAsync(user);
                await _profileRepository.AddProfileAsync(profile);

                // Send activation link to user
				SendMailActivate(user.Email, session, httpContext);

				// Return success result
				result = RegisterResult.Success;
                _logger.LogInformation("[addUser]: Service - End add a new user with result: Register successfully.");
                return result;
            }
            catch (Exception ex) 
            {
                result = RegisterResult.Error;
                _logger.LogError("[addUser]: Service - End add a new user with error: {ex}", ex.StackTrace);
                return result;
            }
		}

		public async Task<ActivateResult> ActivateAccountAsync(string email, string token, ISession session, HttpContext httpContext)
		{
            ActivateResult result;
			try
            {
				// Validate session
				var sessionToken = session.GetString(ACTIVATE_TOKEN);
                var sessionTokenExpiryTime = session.GetString(ACTIVATE_TOKEN_EXPIRY_TIME);
				var user = await _userRepository.GetUserByEmailAsync(email);
				if (string.IsNullOrEmpty(sessionToken) || string.IsNullOrEmpty(sessionTokenExpiryTime) || sessionToken != token || user == null)
				{
                    result = ActivateResult.InvalidToken;
					return result; // Token is invalid
				}

                if (DateTime.Parse(sessionTokenExpiryTime) <= DateTime.UtcNow && !user.IsActive)
                {
                    // Send a new activation link if token is expired
                    SendMailActivate(user.Email, session, httpContext);

					result = ActivateResult.TokenExpired;
                    return result;
				}

				// Unlock the account
				user.IsActive = true;
				await _userRepository.UpdateUserAsync(user);

				// Remove token and other session details
				session.Remove(ACTIVATE_TOKEN);
				session.Remove(ACTIVATE_TOKEN_EXPIRY_TIME);

                result = ActivateResult.Success;
				return result; // Activation successful
			} catch
            {
                result = ActivateResult.Error;
                return result;
            }
		}

		private void SendMailActivate(string email, ISession session, HttpContext httpContext)
		{
			// Generate token and token's expire time
			var activateToken = Guid.NewGuid().ToString();
			var activateTokenExpiryTime = DateTime.UtcNow.AddMinutes(5);

			// Save the token and expiry time in the session
			session.SetString(ACTIVATE_TOKEN, activateToken);
			session.SetString(ACTIVATE_TOKEN_EXPIRY_TIME, activateTokenExpiryTime.ToString());

			// Construct the activation link for the email
			var activationLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Authen/Login?handler=Activate&email={email}&token={activateToken}";
			var mailContent = new MailContent
			{
				To = email,
				Subject = "Activate Account",
				Body = _emailHelper.RenderBodyActiveAccount(activationLink)
			};

			_ = _sendMailUtil.SendMail(mailContent); // Send the email asynchronously
		}

		private static bool IsEmailFormat(string input)
        {
            return input.Contains('@') && input.Contains('.');
        }
	}
}
