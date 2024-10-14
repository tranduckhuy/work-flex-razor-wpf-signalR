using WorkFlex.Web.DTOs;

namespace WorkFlex.Web.ViewModels
{
    public class UserVM
    {
        public ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
