using SCT.Application.DTOs.UserDTOs;

namespace SCT.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> GetAllAsync();
        Task<UserRegistrationResponseDTO> RegisterUser(UserRegistrationRequestDTO requestDTO);
        Task<UserLoginResponseDTO> LoginUser(UserLoginRequestDTO requestDTO);
    }
}
