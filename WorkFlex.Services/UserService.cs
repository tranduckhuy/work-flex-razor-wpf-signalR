using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net.Http;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Repositories;
using WorkFlex.Domain.SearchCiteria;
using WorkFlex.Infrastructure.Utils.Helper.Interface;
using WorkFlex.Infrastructure.Utils.Mail;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;

namespace WorkFlex.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IEmailHelper _emailHelper;
        private readonly SendMailUtil _sendMailUtil;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger,
            IEmailHelper emailHelper, SendMailUtil sendMailUtil)
        {
            _logger = logger;
            _userRepository = userRepository;
            _emailHelper = emailHelper;
            _sendMailUtil = sendMailUtil;
        }

        public async Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(
            int page, UserSearchCriteria? searchCriteria, int roleId, Expression<Func<User, bool>> additionalCriteria = null!)
        {
            var result = await _userRepository.GetUsers(page, searchCriteria, roleId, additionalCriteria);
            return (AppMapper.Mapper.Map<ICollection<UserDto>>(result.Item1), result.Item2);
        }

        public async Task LockUnlockUser(Guid userId)
        {
            await _userRepository.LockUnlockUser(userId);
        }

        public async Task DemotePromoteUser(Guid userId)
        {
            await _userRepository.DemotePromoteUser(userId);
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("[GetByIdAsync]: Service - Start get user by id: {id}", id);
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                _logger.LogDebug("[GetByIdAsync]: Service - User before mapping: {user}", user);
                var userDto = AppMapper.Mapper.Map<UserDto>(user);
                _logger.LogDebug("[GetByIdAsync]: Service - User after mapping: {userDto}", userDto);
                if (userDto == null)
                {
                    _logger.LogInformation("[GetByIdAsync]: Service - End get user by id with status: User Not Found.");
                    return null;
                }
                _logger.LogInformation("[GetByIdAsync]: Service - End get user by id with status: User Found.");
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError("[GetByIdAsync]: Service - End get user by id with error: {ex}", ex.StackTrace);
                return null;
            }
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            await _userRepository.UpdateUserAsync(AppMapper.Mapper.Map<User>(userDto));
        }

        public async Task<bool> RequestRecruiterApproval(Guid userId)
        {
            return await _userRepository.RequestRecruiterApproval(userId);
        }

        public async Task<bool> DeclineRecruiterRequest(Guid userId, ISession session, HttpContext httpContext)
        {

            try
            {
                var user = await _userRepository.DeclineRecruiterRequest(userId);

                // Construct the reset link for the email
                var reapplyLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/";
                var mailContent = new MailContent
                {
                    To = user.Email,
                    Subject = "Recruiter Request Declined",
                    Body = _emailHelper.RenderBodyRecruiterDecline(reapplyLink)
                };

                _ = _sendMailUtil.SendMail(mailContent); // Send the email asynchronously

                return true; // Email successfully sent
            }
            catch
            {
                _logger.LogError("[DeclineRecruiterRequest]: Service - Failed to send email to user with ID: {userId}", userId);
                return false;
            }
        }

        public async Task<bool> ApproveRecruiterRequest(Guid userId, ISession session, HttpContext httpContext)
        {
            try
            {
                var user = await _userRepository.DemotePromoteUser(userId);

                // Construct the reset link for the email
                var approvalLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/";
                var mailContent = new MailContent
                {
                    To = user.Email,
                    Subject = "Recruiter Request Approved",
                    Body = _emailHelper.RenderBodyRecruiterApproval(approvalLink)
                };

                _ = _sendMailUtil.SendMail(mailContent); // Send the email asynchronously

                return true; // Email successfully sent
            }
            catch
            {
                _logger.LogError("[DeclineRecruiterRequest]: Service - Failed to send email to user with ID: {userId}", userId);
                return false;
            }
        }
    }
}
