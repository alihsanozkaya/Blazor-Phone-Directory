using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
