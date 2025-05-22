using SCT.Application.DTOs.UserDTOs;

namespace SCT.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserRegistrationResponseDTO> RegisterUser(UserRegistrationRequestDTO requestDTO, CancellationToken cancellationToken);
        Task<UserLoginResponseDTO> LoginUser(UserLoginRequestDTO requestDTO, CancellationToken cancellationToken);
    }
}
