using WorkFlex.Infrastructure.Constants;

namespace WorkFlex.Services.DTOs
{
    public class LoginResDto
    {
        public AppConstants.LoginResult Result { get; set; }

        public UserDto? User { get; set; }
    }
}
