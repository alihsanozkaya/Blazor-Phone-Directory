using AutoMapper;
using Phone_Directory.Business.Abstract;
using Phone_Directory.DataAccess.Abstract;
using Phone_Directory.Entities.DTOS.Auth;
using Phone_Directory.Entities.DTOS.User;
using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<(UserDto UserDto, bool Success, string Message)> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(updateUserDto.Username);

            if (existingUser != null && existingUser.Id != updateUserDto.Id)
            {
                return (null, false, "Bu kullanıcı adı sitemde mevcut.");
            }

            var updatedUser = _mapper.Map<User>(updateUserDto);
            await _userRepository.UpdateUserAsync(updatedUser);
            var userDto = _mapper.Map<UserDto>(updatedUser);

            return (userDto, true, "Kullanıcı başarıyla güncellendi.");
        }

    }
}
