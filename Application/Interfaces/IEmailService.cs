using SCT.Domain.Entities.EmailService;

namespace SCT.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailRequest email);
    }
}
