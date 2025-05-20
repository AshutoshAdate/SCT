namespace SCT.Application.DTOs.UserDTOs
{
    public record UserRequestDTO
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
