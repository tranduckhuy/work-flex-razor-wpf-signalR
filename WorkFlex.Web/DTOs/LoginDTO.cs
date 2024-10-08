using WorkFlex.Web.Constants;

namespace WorkFlex.Web.DTOs
{
    public class LoginDto
    {
        public AppConstants.LoginResult Result { get; set; }

        public UserDto? User { get; set; }
    }
}
