using SCT.Domain.Entities.EmailService;

namespace SCT.Application.Helper.SMTP
{
    public interface IMailHelper
    {
        Task SendMailAsync(string toMail, string subject, string body);
        void EnqueueEmail(EmailRequest email);
        bool TryDequeue(out EmailRequest email);
    }
}
