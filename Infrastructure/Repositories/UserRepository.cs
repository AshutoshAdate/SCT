using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            var addedUser = await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return addedUser.Entity;

        }

        public async Task<User> CheckUserExists(User user)
        {
            var userLogin = await _context.users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            return userLogin;
        }
    }
}
