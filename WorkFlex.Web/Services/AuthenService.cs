using AutoMapper;
using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Repository.Inteface;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;
using static WorkFlex.Web.Constants.AppConstants;

namespace WorkFlex.Web.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenService> _logger;
        private readonly IUserRepository _userRepository;

        public AuthenService(IMapper mapper, ILogger<AuthenService> logger, IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
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
                        _logger.LogInformation("[checkLogin]: Service - End checking user's authenticate information with result: {result}", LoginResult.AccountLocked);
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

        public bool IsEmailExist(string email)
        {
            return _userRepository.IsEmailExist(email);
        }

        public RegisterResult AddUser(RegisterVM registerVM)
        {
            _logger.LogInformation("[addUser]: Service - Start add a new user");
            RegisterResult result;
            try
            {
                // Check Email that exist in DB or not
                var existingUser = _userRepository.GetUserByEmail(registerVM.Email);
                if (existingUser != null)
                {
                    result = RegisterResult.EmailExist;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: {result}", result);
                    return result;
                }

                // Check Password and RePassword must be matching
                if (registerVM.Password != registerVM.RePassword)
                {
                    result = RegisterResult.NotMatchPassword;
                    _logger.LogInformation("[addUser]: Service - End add a new user with result: {result}", result);
                    return result;
                }

                // if all condition is valid then create a new User
                var user = new User
                {
                    Username = registerVM.Email,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password),
                    IsActive = true,
                    IsLock = false,
                    RoleId = 3,
                    CreatedAt = DateTime.UtcNow
                };
                _logger.LogDebug("[addUser]: Service - User's information: {user}", user);

                // Save user to DB
                _userRepository.AddUser(user);

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
    }
}
