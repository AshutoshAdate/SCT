using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SCT.Application.Helper.EmailTemplate;
using SCT.Domain.Entities.EmailService;
using System.Collections.Concurrent;
namespace SCT.Application.Helper.SMTP
{
    public class MailHelper : IMailHelper
    {
        private readonly EmailSettings _settings;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ConcurrentQueue<EmailRequest> _emails = new();
        public MailHelper(IOptions<EmailSettings> settings, IEmailTemplateService emailTemplateService)
        {
            _settings = settings.Value;
            _emailTemplateService = emailTemplateService;
        }

        public void EnqueueEmail(EmailRequest email)
        {
            _emails.Enqueue(email);
        }

        public bool TryDequeue(out EmailRequest email)
        {
            return _emails.TryDequeue(out email);
        }
        public async Task SendMailAsync(string toMail, string subject, string body)
        {
            try
            {
                var template = await _emailTemplateService.GetPopulatedTemplateAsync("UserRegistered",
            new Dictionary<string, string> { { "UserName", toMail } });
                var email = new MimeMessage();

                email.Subject = subject;
                email.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
                email.To.Add(MailboxAddress.Parse(toMail));
                email.Subject = subject;

                email.Body = new TextPart("html")
                {
                    Text = template.BodyHtml
                };

                using var smtp = new SmtpClient();

                await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.SmtpUser, _settings.SmtpPass);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
    }
}
