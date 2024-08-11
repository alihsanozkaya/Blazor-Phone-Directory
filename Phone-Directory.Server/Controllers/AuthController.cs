using Microsoft.AspNetCore.Mvc;
using Phone_Directory.Business.Abstract;
using Phone_Directory.Constants;
using Phone_Directory.Entities.DTOS.Auth;
using Phone_Directory.Entities.Models;

namespace Phone_Directory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var (userDto, success, message) = await _authService.Register(registerDto);

            if (success)
            {
                return Ok(new { Data = userDto, message });
            }
            else
            {
                return BadRequest(new { message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var userDto = await _authService.Authenticate(loginDto);
            if (userDto == null)
                return Unauthorized(new { message = Messages.InvalidUsernameOrPassword });

            var token = _authService.GenerateJwtToken(new User
            {
                Id = userDto.Id,
                Username = userDto.Username
            });

            return Ok(new { token, userId = userDto.Id, message = Messages.SuccessLogin });
        }

    }
}
