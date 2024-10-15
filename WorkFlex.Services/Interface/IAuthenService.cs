using Microsoft.AspNetCore.Http;
using WorkFlex.Services.DTOs;
using static WorkFlex.Infrastructure.Constants.AppConstants;

namespace WorkFlex.Services.Interface
{
    public interface IAuthenService
    {
        bool IsEmailExist(string email);

        bool SendPasswordResetEmail(string userEmail, ISession session, HttpContext httpContext);

        bool ChangePassword(string newPassword, ISession session);

        bool ActivateAccount(string email, string token, ISession session);

        bool IsAccountLocked(string email);

        LoginResDto? CheckLogin(LoginReqDto loginReqDto);

        RegisterResult AddUser(RegisterDto registerDto, ISession session, HttpContext httpContext);
    }
}
