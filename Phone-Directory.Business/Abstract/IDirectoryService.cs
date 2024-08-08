using Phone_Directory.Entities.DTOS.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Abstract
{
    public interface IDirectoryService
    {
        Task<IEnumerable<DirectoryDto>> GetDirectoriesByUserIdAsync(int userId);
        Task<DirectoryDto> GetDirectoryByIdAsync(int id);
        Task<AddDirectoryDto> AddDirectoryAsync(AddDirectoryDto addDirectoryDto);
        Task<UpdateDirectoryDto> UpdateDirectoryAsync(UpdateDirectoryDto updateDirectoryDto);
        Task DeleteDirectoryAsync(int id);
    }
}
