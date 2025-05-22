using SCT.Application.DTOs.UserContactUsDTOs;

namespace SCT.Application.Interfaces
{
    public interface IContactUsService
    {
        Task<ContactUsResponseDTO> AddUserContact(ContactUsRequestDTO requestDTO, CancellationToken cancellationToken);
    }
}
