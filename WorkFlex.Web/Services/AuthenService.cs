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

        public LoginDTO? checkLogin(LoginVM loginVm)
        {
            User? user;
            if (IsEmailFormat(loginVm.Username))
            {
                user = _userRepository.GetUserByEmail(loginVm.Username);
            }
            else
            {
                user = _userRepository.GetUserByUsername(loginVm.Username);
            }

            var loginDto = new LoginDTO();
            if (user != null)
            {
                if (user.IsLock)
                {
                    loginDto.Result = LoginResult.AccountLocked;
                    return loginDto;
                }

                bool isValidPassword = loginVm.Password == user.Password;
                if (isValidPassword)
                {
                    var userDto = _mapper.Map<UserDTO>(user);
                    loginDto.User = userDto;
                    loginDto.Result = LoginResult.Success;
                }
                else
                {
                    loginDto.Result = LoginResult.InvalidPassword;
                }

                return loginDto;
            }

            loginDto.Result = LoginResult.UserNotFound;
            return loginDto;
        }

        private bool IsEmailFormat(string input)
        {
            return input.Contains("@") && input.Contains(".");
        }
    }
}
