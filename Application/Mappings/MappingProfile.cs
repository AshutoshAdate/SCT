using AutoMapper;
using SCT.Application.DTOs.UserContactUsDTOs;
using SCT.Application.DTOs.UserDTOs;
using SCT.Domain.Entities;

namespace SCT.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();

            CreateMap<User, UserRegistrationResponseDTO>().ReverseMap();
            CreateMap<User, UserRegistrationRequestDTO>().ReverseMap();

            CreateMap<User, UserLoginRequestDTO>().ReverseMap();

            CreateMap<UserContactUs, ContactUsRequestDTO>().ReverseMap();
            CreateMap<UserContactUs, ContactUsResponseDTO>().ReverseMap();

        }
    }
}
