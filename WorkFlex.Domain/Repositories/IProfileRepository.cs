using WorkFlex.Domain.Entities;

namespace WorkFlex.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task AddProfileAsync(Profile profile);
    }
}
