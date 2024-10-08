using WorkFlex.Web.DTOs;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services.Interface
{
    public interface IAuthenService
    {
        LoginDTO? checkLogin(LoginVM loginVm);
    }
}
