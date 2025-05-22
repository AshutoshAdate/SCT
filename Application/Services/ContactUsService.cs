using AutoMapper;
using SCT.Application.DTOs.UserContactUsDTOs;
using SCT.Application.Interfaces;
using SCT.Domain.Entities;
using SCT.Domain.Interfaces;

namespace SCT.Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;

        public ContactUsService(IContactUsRepository contactUsRepository, IMapper mapper)
        {
            _contactUsRepository = contactUsRepository;
            _mapper = mapper;
        }

        public async Task<ContactUsResponseDTO> AddUserContact(ContactUsRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            if (requestDTO == null)
                throw new ArgumentNullException(nameof(requestDTO));
            var userContactEntity = _mapper.Map<UserContactUs>(requestDTO);
            var Response = await _contactUsRepository.AddUserContactAsync(userContactEntity, cancellationToken);
            return _mapper.Map<ContactUsResponseDTO>(Response);
        }
    }
}
