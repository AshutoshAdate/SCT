namespace SCT.Application.Helper.EmailTemplate
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string? TemplateKey { get; set; }
        public string? Subject { get; set; }
        public string? BodyHtml { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
