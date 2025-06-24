namespace SCT.Application.DTOs.UserContactUsDTOs
{
    public record ContactsResponseDTO
    {
        public long ContactId { get; init; }
        public string? ContactName { get; init; }
        public string? Contact { get; init; }
        public string? ContactEmail { get; init; }
        public string? ContactMessage { get; init; }
        //public DateTime CreatedAt { get; init; } = DateTime.Now;
        //public Guid UserId { get; init; }
    }
}
