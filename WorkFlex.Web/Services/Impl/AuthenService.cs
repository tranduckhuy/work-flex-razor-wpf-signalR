using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Services.Impl
{
    public class AuthenService : IAuthenService
    {
        private readonly AppDbContext _appDbContext;

        public AuthenService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User? checkLogin(LoginVM loginVm)
        {
            var user = _appDbContext.Users.SingleOrDefault(u => u.Email == loginVm.Email);
            if (user != null) 
            { 
                return user;
            }
            return null;
        }
    }
}
