using AutoMapper;
using Phone_Directory.Business.Abstract;
using Phone_Directory.DataAccess.Abstract;
using Phone_Directory.Entities.DTOS.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Concrete
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IMapper _mapper;
        public DirectoryService(IDirectoryRepository directoryRepository, IMapper mapper)
        {
            _directoryRepository = directoryRepository;
            _mapper = mapper;
        }
        public async Task<AddDirectoryDto> AddDirectoryAsync(AddDirectoryDto addDirectoryDto)
        {
            var newDirectory = _mapper.Map<Entities.Models.Directory>(addDirectoryDto);
            await _directoryRepository.AddDirectoryAsync(newDirectory);
            return _mapper.Map<AddDirectoryDto>(newDirectory);
        }

        public async Task DeleteDirectoryAsync(int id)
        {
            await _directoryRepository.DeleteDirectoryAsync ( id );
        }

        public async Task<IEnumerable<DirectoryDto>> GetDirectoriesByUserIdAsync(int userId)
        {
            var directories = await _directoryRepository.GetDirectoriesByUserIdAsync(userId);
            var directoryDtos = _mapper.Map<IEnumerable<DirectoryDto>>(directories);
            return directoryDtos;
        }

        public async Task<DirectoryDto> GetDirectoryByIdAsync(int id)
        {
            var directory = await _directoryRepository.GetDirectoryByIdAsync(id);
            return _mapper.Map<DirectoryDto>(directory);
        }

        public async Task<UpdateDirectoryDto> UpdateDirectoryAsync(UpdateDirectoryDto updateDirectoryDto)
        {
            var updatedDirectory = _mapper.Map<Entities.Models.Directory>(updateDirectoryDto);
            await _directoryRepository.UpdateDirectoryAsync(updatedDirectory);
            return _mapper.Map<UpdateDirectoryDto>(updatedDirectory);
        }
    }
}
