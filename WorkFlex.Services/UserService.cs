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
using static WorkFlex.Infrastructure.Constants.AppConstants;

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

        public async Task LockUnlockUser(Guid userId)
        {
            await _userRepository.LockUnlockUser(userId);
        }

        public async Task DemotePromoteUser(Guid userId)
        {
            await _userRepository.DemotePromoteUser(userId);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            await _userRepository.UpdateUserAsync(AppMapper.Mapper.Map<User>(userDto));
        }

        public async Task<bool> RequestRecruiterApproval(Guid userId)
        {
            return await _userRepository.RequestRecruiterApproval(userId);
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

        public async Task<bool> UpdateUserProfileAsync(ProfileDto profileDto)
        {
            _logger.LogInformation("[UpdateUserProfileAsync]: Service - Start updating user: {id}", profileDto.Id);

            try
            {
                var user = await _userRepository.GetUserByIdAsync(profileDto.Id);
                if (user == null)
                {
                    _logger.LogInformation("[UpdateUserProfileAsync]: Service - End updating user: {id} with status: User Not Found.", profileDto.Id);
                    return false;
                }
                
                _logger.LogDebug("[UpdateUserProfileAsync]: Service - User before update: {user}", user);
                user.FirstName = profileDto.FirstName;
                user.LastName = profileDto.LastName;
                user.Phone = profileDto.Phone;
                user.Email = profileDto.Email;
                user.Profile.Headline = profileDto.Headline ?? "";
                //user.Website = profileDto.Website ?? "";

                var locationParts = new List<string>
                {
                    profileDto.Street!,
                    profileDto.Apartment!,
                    profileDto.Ward!,     
                    profileDto.District!, 
                    profileDto.Province!  
                };
                user.Location = string.Join(", ", locationParts.Where(part => !string.IsNullOrWhiteSpace(part)));

                user.Profile.Summary = profileDto.AboutDescription ?? "";
                _logger.LogDebug("[UpdateUserProfileAsync]: Service - User after update: {user}", user);

                await _userRepository.UpdateUserAsync(user);
                return true;
            } catch (Exception ex)
            {
                _logger.LogError("[UpdateUserProfileAsync]: Service - End updating user: {id} with error: {ex}", profileDto.Id, ex.StackTrace);
                return false;
            }
        }

        public async Task<ProfileResult> ChangePasswordAsync(ProfileDto profileDto)
        {
            _logger.LogInformation("[ChangePasswordAsync]: Service - Start changing password for user: {id}", profileDto.Id);

            if (profileDto.NewPassword != profileDto.ReEnterPassword)
            {
                _logger.LogInformation("[ChangePasswordAsync]: Service - End changing password for user: {id} with status: Password not match.", profileDto.Id);
                return ProfileResult.PasswordNotMatch;
            }

            try
            {
                var user = await _userRepository.GetUserByIdAsync(profileDto.Id);
                if (user == null)
                {
                    _logger.LogInformation("[ChangePasswordAsync]: Service - End changing password for user: {id} with status: User Not Found.", profileDto.Id);
                    return ProfileResult.UserNotFound;
                }

                bool isValidOldPass = BCrypt.Net.BCrypt.Verify(profileDto.OldPassword, user.Password);
                if (!isValidOldPass) 
                {
                    _logger.LogInformation("[ChangePasswordAsync]: Service - End changing password for user: {id} with status: Wrong Old Password.", profileDto.Id);
                    return ProfileResult.InvalidPassword;
                }

                _logger.LogInformation("[UpdateUserProfileAsync]: Service - User before update: {user}", user);
                user.Password = BCrypt.Net.BCrypt.HashPassword(profileDto.NewPassword);
                _logger.LogInformation("[UpdateUserProfileAsync]: Service - User after update: {user}", user);

                await _userRepository.UpdateUserAsync(user);
                return ProfileResult.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError("[ChangePasswordAsync]: Service - End changing password for user: {id} with error: {ex}", profileDto.Id, ex.StackTrace);
                return ProfileResult.Error;
            }
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

        public async Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(
            int page, UserSearchCriteria? searchCriteria, int roleId)
        {
            var result = await _userRepository.GetUsers(page, searchCriteria, roleId);
            return (AppMapper.Mapper.Map<ICollection<UserDto>>(result.Item1), result.Item2);
        }

        public async Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(
            int page, UserSearchCriteria? searchCriteria, int roleId, Expression<Func<User, bool>> additionalCriteria = null!)
        {
            var result = await _userRepository.GetUsers(page, searchCriteria, roleId, additionalCriteria);
            return (AppMapper.Mapper.Map<ICollection<UserDto>>(result.Item1), result.Item2);
        }
    }
}
