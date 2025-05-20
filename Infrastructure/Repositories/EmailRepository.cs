using Microsoft.EntityFrameworkCore;
using SCT.Application.Helper.EmailTemplate;
using SCT.Application.Interfaces;
using SCT.Infrastructure.Data;

namespace SCT.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _context;

        public EmailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailTemplate?> GetEmailTemplateAsync(EmailTemplate emailTemplate)
        {
            return await _context.emailTemplates.FirstOrDefaultAsync(t => t.TemplateKey == emailTemplate.TemplateKey);

        }
    }
}
