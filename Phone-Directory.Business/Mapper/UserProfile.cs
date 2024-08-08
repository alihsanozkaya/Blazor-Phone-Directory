using AutoMapper;
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
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<RegisterDto, User>();
            CreateMap<RegisterDto, User>().ReverseMap();

            CreateMap<LoginDto, User>();
            CreateMap<LoginDto, User>().ReverseMap();
        }
    }
}
