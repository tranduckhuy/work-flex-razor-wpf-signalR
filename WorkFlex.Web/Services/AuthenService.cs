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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public LoginDto? checkLogin(LoginVM loginVm)
        {
            var loginDto = new LoginDto();
            try
            {
                User? user;
                // If user using email for log in then check email
                if (isEmailFormat(loginVm.Username))
                {
                    user = _userRepository.getUserByEmail(loginVm.Username);
                }
                // If user using username for log in then check username
                else
                {
                    user = _userRepository.getUserByUsername(loginVm.Username);
                }

                if (user != null)
                {
                    // If user's account is locked then notify and not allow user access into the system
                    if (user.IsLock)
                    {
                        loginDto.Result = LoginResult.AccountLocked;
                        return loginDto;
                    }

                    // Check password user input that true or not
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(loginVm.Password, user.Password);
                    if (isValidPassword)
                    {
                        var userDto = _mapper.Map<UserDto>(user);
                        loginDto.User = userDto;
                        loginDto.Result = LoginResult.Success;
                    }
                    else
                    {
                        loginDto.Result = LoginResult.InvalidPassword;
                    }

                    return loginDto;
                }
                else
                {
                    loginDto.Result = LoginResult.UserNotFound;
                    return loginDto;
                }
            }
            catch
            {
                loginDto.Result = LoginResult.Error;
                return loginDto;
            }
        }

        public bool isEmailExist(string email)
        {
            return _userRepository.isEmailExist(email);
        }

        public RegisterResult addUser(RegisterVM registerVM)
        {
            RegisterResult result;
            try
            {
                // Check Email that exist in DB or not
                var existingUser = _userRepository.getUserByEmail(registerVM.Email);
                if (existingUser != null)
                {
                    result = RegisterResult.EmailExist;
                    return result;
                }

                // Check Password and RePassword must be matching
                if (registerVM.Password != registerVM.RePassword)
                {
                    result = RegisterResult.NotMatchPassword;
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

                // Save user to DB
                _userRepository.addUser(user);

                // Return success result
                result = RegisterResult.Success;
                return result;
            }
            catch
            {
                result = RegisterResult.Error;
                return result;
            }
        }

        private static bool isEmailFormat(string input)
        {
            return input.Contains("@") && input.Contains(".");
        }
    }
}
