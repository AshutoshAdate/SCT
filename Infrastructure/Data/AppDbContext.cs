using Microsoft.EntityFrameworkCore;
using SCT.Application.Helper.EmailTemplate;
using SCT.Domain.Entities;

namespace SCT.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<EmailTemplate> emailTemplates { get; set; }
    }
}
