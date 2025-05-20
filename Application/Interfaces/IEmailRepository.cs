using SCT.Application.Helper.EmailTemplate;

namespace SCT.Application.Interfaces
{
    public interface IEmailRepository
    {
        Task<EmailTemplate?> GetEmailTemplateAsync(EmailTemplate emailTemplate);
    }
}
