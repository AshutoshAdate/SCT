using AutoMapper;
using SCT.Application.DTOs.UserDTOs;
using SCT.Application.Helper;
using SCT.Application.Helper.SMTP;
using SCT.Application.Interfaces;
using SCT.Domain.Entities;
using SCT.Domain.Interfaces;

namespace SCT.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthHelper _authHelper;
        private readonly IMailHelper _mailHelper;
        //private readonly MailHelper _mailHelper1;
        public UserService(IUserRepository userRepository, IMapper mapper, IAuthHelper authHelper, IMailHelper mailHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authHelper = authHelper;
            _mailHelper = mailHelper;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<UserResponseDTO>>(users);
        }

        public async Task<UserRegistrationResponseDTO> RegisterUser(UserRegistrationRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var hashedPassword = _authHelper.HashPassword(requestDTO.Password);
            var reqDto = new UserRegistrationRequestDTO
            {
                Name = requestDTO.Name,
                Email = requestDTO.Email,
                UserName = requestDTO.UserName,
                PhoneNumber = requestDTO.PhoneNumber,
                Password = hashedPassword,
            };
            // Map DTO to Entity
            var userEntity = _mapper.Map<User>(reqDto);

            // Save to database
            var createdUser = await _userRepository.RegisterUserAsync(userEntity,cancellationToken);

            //send mail to user
            //await _mailHelper.SendMailAsync(createdUser.Email, "Welcome to SCT", "user created");
            // Map Entity back to Response DTO
            return _mapper.Map<UserRegistrationResponseDTO>(createdUser);
        }

        public async Task<UserLoginResponseDTO> LoginUser(UserLoginRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            //check user if exists

            var userEntity = _mapper.Map<User>(requestDTO);
            var user = await _userRepository.CheckUserExists(userEntity, cancellationToken);

            if (user == null)
            {

                return new UserLoginResponseDTO
                {
                    Message = "Invalid User/Not Found"
                };
            }

            if (user == null || !_authHelper.VerifyPassword(requestDTO.Password, user.Password))
            {
                return new UserLoginResponseDTO
                {
                    Message = "Invalid User/Not Found"
                };
            }
            var Token = _authHelper.GenerateToken(requestDTO.UserName, requestDTO.Password);

            return new UserLoginResponseDTO
            {
                Message = "Loggedin Successfully",
                UserName = user.UserName,
                Token = Token
            };

        }
    }
}
