namespace SCT.Application.Helper.EmailTemplate
{
    public interface IEmailTemplateService
    {
        Task<(string Subject, string BodyHtml)> GetPopulatedTemplateAsync(string templateKey, Dictionary<string, string> placeholders);
    }
}
