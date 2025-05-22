using System.ComponentModel.DataAnnotations;

namespace SCT.Application.DTOs.UserContactUsDTOs
{
    public record ContactUsRequestDTO
    {
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string? ContactName { get; init; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? ContactEmail { get; init; }
        public string? ContactMessage { get; init; }
    }
}
