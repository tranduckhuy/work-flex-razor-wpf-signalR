using WorkFlex.Domain.Entities;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services
{
    public interface IAuthenService
    {
        User? checkLogin(LoginVM loginVm);
    }
}
