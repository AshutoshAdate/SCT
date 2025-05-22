using SCT.Domain.Entities;

namespace SCT.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User> RegisterUserAsync(User user,CancellationToken cancellationToken);
        Task<User> CheckUserExists(User user, CancellationToken cancellationToken);
    }
}
