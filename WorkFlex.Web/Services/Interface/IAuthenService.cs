using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;
using static WorkFlex.Web.Constants.AppConstants;

namespace WorkFlex.Web.Services.Interface
{
    public interface IAuthenService
    {
        LoginDto? CheckLogin(LoginVM loginVm);

        RegisterResult AddUser(RegisterVM registerVm);

        bool IsEmailExist(string email);
    }
}
