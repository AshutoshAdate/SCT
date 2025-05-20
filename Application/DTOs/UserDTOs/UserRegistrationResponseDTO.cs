namespace SCT.Application.DTOs.UserDTOs
{
    public record UserRegistrationResponseDTO
    {
        public string? UserName { get; init; }
        public string? UserID { get; init; }
    }
}
