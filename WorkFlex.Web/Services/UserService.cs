using WorkFlex.Web.Repository.Inteface;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.DTOs;
using AutoMapper;

namespace WorkFlex.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Get All Users
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        Task<IEnumerable<UserDTO>> IUserService.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
