using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCT.Application.DTOs.UserDTOs;
using SCT.Application.Interfaces;

namespace SCT.API.Controllers.UserControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles ="admin")]
        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync(cancellationToken);
            return users == null ? NotFound() : Ok(users);
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegistrationRequestDTO requestDTO,CancellationToken cancellationToken)
        {
            var user = await _userService.RegisterUser(requestDTO, cancellationToken);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO,CancellationToken cancellationToken)
        {
            var loginDetails = await _userService.LoginUser(userLoginRequestDTO, cancellationToken);
            return loginDetails == null ? NotFound() : Ok(loginDetails);
        }
    }
}
