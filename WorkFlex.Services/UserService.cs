using Microsoft.Extensions.Logging;
using WorkFlex.Domain;
using WorkFlex.Domain.Repositories;
using WorkFlex.Domain.SearchCiteria;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Services.Mapping;

namespace WorkFlex.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<(ICollection<UserDto>, Pageable<UserSearchCriteria>)> GetUsers(
            int page, UserSearchCriteria? searchCriteria, int roleId)
        {
            var result = await _userRepository.GetUsers(page, searchCriteria, roleId);
            return (AppMapper.Mapper.Map<ICollection<UserDto>>(result.Item1), result.Item2);
        }

        public async Task LockUnlockUser(Guid userId)
        {
            await _userRepository.LockUnlockUser(userId);
        }

        public async Task DemotePromoteUser(Guid userId)
        {
            await _userRepository.LockUnlockUser(userId);
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
    }
}
