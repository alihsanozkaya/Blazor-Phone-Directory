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
        Task<User> Register(RegisterDto registerDto);
        Task<UserDto> Authenticate(LoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
