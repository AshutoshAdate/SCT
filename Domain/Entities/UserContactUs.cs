using System.ComponentModel.DataAnnotations;

namespace SCT.Domain.Entities
{
    public class UserContactUs
    {
        [Key]
        public long ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? Contact { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMessage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
