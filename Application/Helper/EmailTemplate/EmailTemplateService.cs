using SCT.Application.Interfaces;

namespace SCT.Application.Helper.EmailTemplate
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IEmailRepository _emailRepository;
        public EmailTemplateService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<(string Subject, string BodyHtml)> GetPopulatedTemplateAsync(string templateKey, Dictionary<string, string> placeholders)
        {

            var template = await _emailRepository.GetEmailTemplateAsync(new EmailTemplate
            {
                TemplateKey = templateKey,
            });

            if (template == null)
                throw new Exception($"Email template '{templateKey}' not found.");

            string body = template.BodyHtml;
            string subject = template.Subject;

            foreach (var kvp in placeholders)
            {
                body = body.Replace($"{{{{{kvp.Key}}}}}", kvp.Value);
                subject = subject.Replace($"{{{{{kvp.Key}}}}}", kvp.Value);
            }

            return (subject, body);
        }
    }
}
