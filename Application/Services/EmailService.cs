using SCT.Application.Helper.SMTP;
using SCT.Application.Interfaces;
using SCT.Domain.Entities.EmailService;

namespace SCT.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IMailHelper _mailHelper;
        public EmailService(ILogger<EmailService> logger, IMailHelper mailHelper)
        {
            _logger = logger;
            _mailHelper = mailHelper;
        }

        public async Task<bool> SendEmailAsync(EmailRequest email)
        {
            try
            {
                await _mailHelper.SendMailAsync(email.To, email.Subject, email.Body);
                _logger.LogInformation($"Email sent to {email.To}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
