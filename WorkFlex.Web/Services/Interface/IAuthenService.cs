using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;
using static WorkFlex.Web.Constants.AppConstants;

namespace WorkFlex.Web.Services.Interface
{
    public interface IAuthenService
    {
        LoginDto? checkLogin(LoginVM loginVm);

        RegisterResult addUser(RegisterVM registerVm);

        bool isEmailExist(string email);
    }
}
