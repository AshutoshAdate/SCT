using Microsoft.EntityFrameworkCore;
using SCT.Domain.Entities;
using SCT.Domain.Interfaces;
using SCT.Infrastructure.Data;

namespace SCT.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<User> RegisterUserAsync(User user, CancellationToken cancellationToken)
        {
            var addedUser = await _context.users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync();
            return addedUser.Entity;

        }

        public async Task<User> CheckUserExists(User user, CancellationToken cancellationToken)
        {
            var userLogin = await _context.users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == user.UserName, cancellationToken);
            return userLogin;
        }
    }
}
