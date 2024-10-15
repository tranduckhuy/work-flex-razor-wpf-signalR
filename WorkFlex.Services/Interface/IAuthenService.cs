using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;
using static WorkFlex.Web.Constants.AppConstants;
using Microsoft.AspNetCore.Http;
using WorkFlex.Services.DTOs;
using static WorkFlex.Infrastructure.Constants.AppConstants;

namespace WorkFlex.Services.Interface
{
    public interface IAuthenService
    {
        bool IsEmailExist(string email);

        bool SendMailResetEmail(string userEmail, ISession session, HttpContext httpContext);

        bool ChangePassword(string newPassword, ISession session);

        bool IsAccountLocked(string email);

        LoginResDto? CheckLogin(LoginReqDto loginReqDto);

        RegisterResult AddUser(RegisterDto registerDto, ISession session, HttpContext httpContext);

		ActivateResult ActivateAccount(string email, string token, ISession session, HttpContext httpContext);
	}
}
