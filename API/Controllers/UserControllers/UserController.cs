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

        [Authorize]
        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return users == null ? NotFound() : Ok(users);
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegistrationRequestDTO requestDTO)
        {
            var user = await _userService.RegisterUser(requestDTO);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            var loginDetails = await _userService.LoginUser(userLoginRequestDTO);
            return loginDetails == null ? NotFound() : Ok(loginDetails);
        }
    }
}
