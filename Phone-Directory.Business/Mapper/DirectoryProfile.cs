using AutoMapper;
using Phone_Directory.Entities.DTOS.Directory;
using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Business.Mapper
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<DirectoryDto, Entities.Models.Directory>();
            CreateMap<DirectoryDto, Entities.Models.Directory>().ReverseMap();

            CreateMap<AddDirectoryDto, Entities.Models.Directory>();
            CreateMap<AddDirectoryDto, Entities.Models.Directory>().ReverseMap();

            CreateMap<UpdateDirectoryDto, Entities.Models.Directory>();
            CreateMap<UpdateDirectoryDto, Entities.Models.Directory>().ReverseMap();
        }
    }
}
