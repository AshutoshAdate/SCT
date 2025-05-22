using Microsoft.AspNetCore.Mvc;
using SCT.Application.DTOs.UserContactUsDTOs;
using SCT.Application.Interfaces;

namespace SCT.API.Controllers.ContactUsContrller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpPost("addusercontact")]
        public async Task<ActionResult> AddContactDetails(ContactUsRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var response = await _contactUsService.AddUserContact(requestDTO, cancellationToken);

            return response == null ? NoContent() : Ok(response);
        }

    }
}
