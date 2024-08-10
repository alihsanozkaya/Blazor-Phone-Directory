using Phone_Directory.Entities.DTOS.Auth;
using Phone_Directory.Entities.DTOS.Directory;
using Phone_Directory.Entities.DTOS.User;
using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Abstract
{
    public interface IAuthService
    {
        Task<(UserDto UserDto, bool Success, string Message)> Register(RegisterDto registerDto);
        Task<UserDto> Authenticate(LoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
