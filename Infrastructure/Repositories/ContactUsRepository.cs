using SCT.Domain.Entities;
using SCT.Domain.Interfaces;
using SCT.Infrastructure.Data;

namespace SCT.Infrastructure.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly AppDbContext _context;

        public ContactUsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserContactUs> AddUserContactAsync(UserContactUs userContactUs, CancellationToken cancellationToken)
        {
            var response = await _context.userContactUs.AddAsync(userContactUs, cancellationToken);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

    }
}
