﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Repository.Interface;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.Untils.Mail;
using WorkFlex.Web.ViewModels;
using static WorkFlex.Web.Constants.AppConstants;

namespace WorkFlex.Web.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenService> _logger;
        private readonly IUserRepository _userRepository;
		private readonly IEmailHelper _emailHelper;
		private readonly SendMailUtil _sendMailUtil;

        private const string RESET_TOKEN = "ResetToken";
        private const string RESET_TOKEN_EXPIRY_TIME = "ResetTokenExpiryTime";
        private const string RESET_TOKEN_USER_EMAIL = "ResetTokenUserEmail";

        private const string ACTIVATE_TOKEN = "ActivateToken";
        private const string ACTIVATE_TOKEN_EXPIRY_TIME = "ActivateTokenExpiryTime";

		public AuthenService(IMapper mapper, ILogger<AuthenService> logger, IUserRepository userRepository, IEmailHelper emailHelper, SendMailUtil sendMailUtil)
        {
            _mapper = mapper;
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

        public bool SendMailResetEmail(string userEmail, ISession session, HttpContext httpContext)
        {
            try
            {
				var user = _userRepository.GetUserByEmail(userEmail);
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

        public bool ChangePassword(string newPassword, ISession session)
        {
            try
            {
				var sessionToken = session.GetString(RESET_TOKEN);
				var sessionTokenExpiryTime = session.GetString(RESET_TOKEN_EXPIRY_TIME);
				var sessionUserEmail = session.GetString(RESET_TOKEN_USER_EMAIL);
				var user = _userRepository.GetUserByEmail(sessionUserEmail!);

				// Validate session: check token existence, expiry time, and user email
				if (string.IsNullOrEmpty(sessionToken) || 
                    string.IsNullOrEmpty(sessionTokenExpiryTime) || 
                    string.IsNullOrEmpty(sessionUserEmail) ||
                    user == null ||
					DateTime.Parse(sessionTokenExpiryTime!) > DateTime.UtcNow)
				{
					return false; // Token is invalid, expired, user email is empty or user is not found
				}

				// Hash the new password and update the user
				user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
				_userRepository.UpdateUser(user); // Save changes

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

        public LoginDto? CheckLogin(LoginVM loginVm)
        {
            _logger.LogInformation("[checkLogin]: Service - Start checking user's authenticate information");
            var loginDto = new LoginDto();
            try
            {
                User? user;
                // If user using email for log in then check email
                if (IsEmailFormat(loginVm.Username))
                {
                    user = _userRepository.GetUserByEmail(loginVm.Username);
                }
                // If user using username for log in then check username
                else
                {
                    user = _userRepository.GetUserByUsername(loginVm.Username);
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
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginVm.Password, user.Password);
                    if (isValidPassword)
                    {
                        var userDto = _mapper.Map<UserDto>(user);
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

        public RegisterResult AddUser(RegisterVM registerVm, ISession session, HttpContext httpContext)
        {
            _logger.LogInformation("[addUser]: Service - Start add a new user");
            RegisterResult result;
            try
            {
                // Check Email that exist in DB or not
                var existingUser = _userRepository.GetUserByEmail(registerVm.Email);
                if (existingUser != null)
                {
                    result = RegisterResult.EmailExist;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: Email exist.");
                    return result;
                }

                // Check Password and RePassword must be matching
                if (registerVm.Password != registerVm.RePassword)
                {
                    result = RegisterResult.NotMatchPassword;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: New password and re-peat password not match.");
                    return result;
                }

                // if all condition is valid then create a new User
                var user = new User
                {
                    Username = registerVm.Email,
                    FirstName = registerVm.FirstName,
                    LastName = registerVm.LastName,
                    Email = registerVm.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVm.Password),
                    Avatar = DEFAULT_AVATAR,
                    IsActive = false,
                    IsLock = false,
                    RoleId = 3,
                    CreatedAt = DateTime.UtcNow
                };
                _logger.LogDebug("[addUser]: Service - User's information: {user}", user);

                // Save user to DB
                _userRepository.AddUser(user);

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

		public ActivateResult ActivateAccount(string email, string token, ISession session, HttpContext httpContext)
		{
            ActivateResult result;
			try
            {
				// Validate session
				var sessionToken = session.GetString(ACTIVATE_TOKEN);
                var sessionTokenExpiryTime = session.GetString(ACTIVATE_TOKEN_EXPIRY_TIME);
				var user = _userRepository.GetUserByEmail(email);
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
				_userRepository.UpdateUser(user);

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
