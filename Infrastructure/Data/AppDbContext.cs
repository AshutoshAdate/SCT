using Microsoft.EntityFrameworkCore;
using SCT.Application.Helper.EmailTemplate;
using SCT.Domain.Entities;
using SCT.Domain.Entities.EmailService;

namespace SCT.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<EmailTemplate> emailTemplates { get; set; }
        public DbSet<UserContactUs> userContactUs { get; set; }
        public DbSet<EmailRequest> EmailRequests { get; set; }
    }
}
