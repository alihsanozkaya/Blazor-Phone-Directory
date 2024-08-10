using Phone_Directory.Entities.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Abstract
{
    public interface IUserService
    {
        Task<(UserDto UserDto, bool Success, string Message)> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<UserDto> GetUserAsync(int id);
    }
}
