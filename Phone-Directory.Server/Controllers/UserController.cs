using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phone_Directory.Business.Abstract;
using Phone_Directory.Entities.DTOS.User;

namespace Phone_Directory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "Kullanıcı bulunamadı"});
            }
            return Ok(new {Data = user, Message = "Kullanıcı getirildi"});
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var updatedUser = await _userService.UpdateUserAsync(updateUserDto);

            if (!updatedUser.Success)
            {
                return BadRequest(new { Message = updatedUser.Message });
            }

            return Ok(new { Data = updatedUser.UserDto, Message = updatedUser.Message });
        }

    }
}
