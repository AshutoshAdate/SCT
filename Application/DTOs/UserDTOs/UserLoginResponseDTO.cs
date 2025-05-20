namespace SCT.Application.DTOs.UserDTOs
{
    public record UserLoginResponseDTO
    {
        public string? UserName { get; init; }
        public string? Token { get; init; }
        public string? Message { get; init; }
    }
}
