using AutoMapper;
using Phone_Directory.Entities.DTOS.Auth;
using Phone_Directory.Entities.DTOS.User;
using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

            CreateMap<LoginDto, User>().ReverseMap();

            CreateMap<UpdateUserDto, User>().ReverseMap();
        }
    }
}
