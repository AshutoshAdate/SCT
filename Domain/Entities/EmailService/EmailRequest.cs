namespace SCT.Domain.Entities.EmailService
{
    public class EmailRequest
    {
        public int Id { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? From { get; set; }
        public string? CC { get; set; }
        public string? BCC { get; set; }
        public EmailStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
