namespace SCT.Application.DTOs.UserDTOs
{
    public record UserResponseDTO
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? UserName { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
