using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.DataAccess.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
