using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.DataAccess.Abstract
{
    public interface IDirectoryRepository
    {
        Task<IEnumerable<Entities.Models.Directory>> GetDirectoriesByUserIdAsync(int userId);
        Task<Entities.Models.Directory> GetDirectoryByIdAsync(int id);
        Task AddDirectoryAsync(Entities.Models.Directory directory);
        Task UpdateDirectoryAsync(Entities.Models.Directory directory);
        Task DeleteDirectoryAsync(int id);
    }
}
