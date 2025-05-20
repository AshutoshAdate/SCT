namespace SCT.Application.Helper.SMTP
{
    public interface IMailHelper
    {
        Task SendMailAsync(string toMail, string subject, string body);
    }
}
