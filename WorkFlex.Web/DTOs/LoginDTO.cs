using WorkFlex.Web.Constants;

namespace WorkFlex.Web.DTOs
{
    public class LoginDTO
    {
        public AppConstants.LoginResult Result { get; set; }
        public UserDTO? User { get; set; }
    }
}
