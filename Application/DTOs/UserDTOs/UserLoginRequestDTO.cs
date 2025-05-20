namespace SCT.Application.DTOs.UserDTOs
{
    public record UserLoginRequestDTO
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
