using AutoMapper;
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

namespace WorkFlex.Services.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly ILogger<AuthenService> _logger;
        private readonly IUserRepository _userRepository;
		private readonly IEmailHelper _emailHelper;
		private readonly SendMailUtil _sendMailUtil;

		public AuthenService(ILogger<AuthenService> logger, IUserRepository userRepository, IEmailHelper emailHelper, SendMailUtil sendMailUtil)
        {
            _logger = logger;
            _userRepository = userRepository;
            _emailHelper = emailHelper;
            _sendMailUtil = sendMailUtil;
        }

        public bool IsEmailExist(string email)
        {
            return _userRepository.IsEmailExist(email);
        }

        public bool IsAccountLocked(string email)
        {
            return _userRepository.IsAccountLocked(email);
        }

        public bool SendPasswordResetEmail(string userEmail, ISession session, HttpContext httpContext)
        {
            var user = _userRepository.GetUserByEmail(userEmail);
            if (user == null)
            {
                return false; // User not found
            }

            var resetToken = Guid.NewGuid().ToString();
            var resetTokenExpiryTime = DateTime.UtcNow.AddMinutes(5);

            // Save the token and expiry time in the session
            session.SetString("ResetToken", resetToken);
            session.SetString("ResetTokenExpiryTime", resetTokenExpiryTime.ToString());
            session.SetString("ResetTokenUserEmail", userEmail);

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
        }

        public bool ChangePassword(string newPassword, ISession session)
        {
            var userEmailFromSession = session.GetString("ResetTokenUserEmail");

            // Validate session
            if (!IsTokenValid(session, "ResetToken", "ResetTokenExpiryTime") ||
                string.IsNullOrEmpty(userEmailFromSession))
            {
                return false; // Token is invalid or has expired
            }

            var user = _userRepository.GetUserByEmail(userEmailFromSession);
            if (user == null)
            {
                return false; // User not found
            }

            // Hash the new password and update the user
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _userRepository.UpdateUser(user); // Save changes

            // Remove token and other session details
            session.Remove("ResetToken");
            session.Remove("ResetTokenExpiryTime");
            session.Remove("ResetTokenUserEmail");

            return true; // Password successfully reset
        }

        public bool ActivateAccount(string email, string token, ISession session)
        {
            // Validate session
            if (!IsTokenValid(session, "ActivateToken", "ActivateTokenExpiryTime"))
            {
                return false; // Token is invalid or has expired
            }

            var sessionToken = session.GetString("ActivateToken");

            // Check if user exists and if the token matches
            if (sessionToken != token)
            {
                return false; // Token mismatch
            }

            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return false; // User not found
            }

            // Unlock the account
            user.IsLock = false;
            _userRepository.UpdateUser(user);

            // Remove token and other session details
            session.Remove("ActivateToken");
            session.Remove("ActivateTokenExpiryTime");

            return true; // Activation successful
        }

        public LoginResDto? CheckLogin(LoginReqDto loginReqDto)
        {
            _logger.LogInformation("[checkLogin]: Service - Start checking user's authenticate information");
            var loginDto = new LoginResDto();
            try
            {
                User? user;
                // If user using email for log in then check email
                if (IsEmailFormat(loginReqDto.Username))
                {
                    user = _userRepository.GetUserByEmail(loginReqDto.Username);
                }
                // If user using username for log in then check username
                else
                {
                    user = _userRepository.GetUserByUsername(loginReqDto.Username);
                }

                if (user != null)
                {
                    _logger.LogDebug("[checkLogin]: Service - User's information: {user}", user);
                    // If user's account is locked then notify and not allow user access into the system
                    if (user.IsLock)
                    {
                        loginDto.Result = LoginResult.AccountLocked;
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: {result}", LoginResult.AccountLocked);
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
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: {result}", LoginResult.Success);
                    }
                    else
                    {
                        loginDto.Result = LoginResult.InvalidPassword;
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: {result}", LoginResult.InvalidPassword);
                    }

                    return loginDto;
                }
                else
                {
                    loginDto.Result = LoginResult.UserNotFound;
                    _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: {result}", LoginResult.UserNotFound);
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

        public RegisterResult AddUser(RegisterDto registerDto, ISession session, HttpContext httpContext)
        {
            _logger.LogInformation("[addUser]: Service - Start add a new user");
            RegisterResult result;
            try
            {
                // Check Email that exist in DB or not
                var existingUser = _userRepository.GetUserByEmail(registerDto.Email);
                if (existingUser != null)
                {
                    result = RegisterResult.EmailExist;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: {result}", result);
                    return result;
                }

                // Check Password and RePassword must be matching
                if (registerDto.Password != registerDto.RePassword)
                {
                    result = RegisterResult.NotMatchPassword;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: {result}", result);
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
                    IsActive = true,
                    Avatar = DEFAULT_AVATAR,
                    IsLock = true,
                    RoleId = 3,
                    CreatedAt = DateTime.UtcNow
                };
                _logger.LogDebug("[addUser]: Service - User's information: {user}", user);

                // Save user to DB
                _userRepository.AddUser(user);

                // Generate token and token's expire time
				var activateToken = Guid.NewGuid().ToString();
				var activateTokenExpiryTime = DateTime.UtcNow.AddMinutes(5);

				// Save the token and expiry time in the session
				session.SetString("ActivateToken", activateToken);
				session.SetString("ActivateTokenExpiryTime", activateTokenExpiryTime.ToString());

				// Construct the activation link for the email
				var activationLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Authen/Login?handler=Activate&email={user.Email}&token={activateToken}";
				var mailContent = new MailContent
				{
					To = user.Email,
					Subject = "Activate Account",
					Body = _emailHelper.RenderBodyActiveAccount(activationLink)
				};

				_ = _sendMailUtil.SendMail(mailContent); // Send the email asynchronously

				// Return success result
				result = RegisterResult.Success;
                _logger.LogInformation("[addUser]: Service - End add a new user with result: {result}", result);
                return result;
            }
            catch (Exception ex) 
            {
                result = RegisterResult.Error;
                _logger.LogError("[addUser]: Service - End add a new user with error: {ex}", ex.StackTrace);
                return result;
            }
		}

        private static bool IsEmailFormat(string input)
        {
            return input.Contains("@") && input.Contains(".");
        }

        private bool IsTokenValid(ISession session, string tokenKey, string expiryTimeKey)
        {
            var sessionToken = session.GetString(tokenKey);
            var sessionExpiryTime = session.GetString(expiryTimeKey);

            // Check if the token or expiry time is invalid or expired
            return !string.IsNullOrEmpty(sessionToken) &&
                   !string.IsNullOrEmpty(sessionExpiryTime) &&
                   DateTime.Parse(sessionExpiryTime) > DateTime.UtcNow;
        }

    }
}
