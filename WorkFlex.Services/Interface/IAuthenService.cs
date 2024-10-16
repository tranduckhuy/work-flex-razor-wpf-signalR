using Microsoft.AspNetCore.Http;
using WorkFlex.Services.DTOs;
using static WorkFlex.Infrastructure.Constants.AppConstants;

namespace WorkFlex.Services.Interface
{
    public interface IAuthenService
    {
        Task<bool> IsEmailExistAsync(string email);

        Task<bool> SendMailResetEmailAsync(string userEmail, ISession session, HttpContext httpContext);

        Task<bool> ChangePasswordAsync(string newPassword, ISession session);

        Task<bool> IsAccountLockedAsync(string email);

        Task<LoginResDto?> CheckLoginAsync(LoginReqDto loginReqDto);

        Task<RegisterResult> AddUserAsync(RegisterDto registerDto, ISession session, HttpContext httpContext);

        Task<ActivateResult> ActivateAccountAsync(string email, string token, ISession session, HttpContext httpContext);
    }
}
