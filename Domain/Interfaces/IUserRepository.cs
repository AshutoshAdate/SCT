using SCT.Domain.Entities;

namespace SCT.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> RegisterUserAsync(User user);
        Task<User> CheckUserExists(User user);
    }
}
