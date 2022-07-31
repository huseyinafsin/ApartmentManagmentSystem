using AutoMapper;
using Core.Entity.Concrete;
using Entity.Concrete;
using Entity.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.Dtos.Resident;

namespace Bussiness.Configuration.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,ManagerForRegister>();
            CreateMap<Manager,ManagerForRegister>();
            CreateMap<User,ResidentForRegister>();
            CreateMap<Resident,ResidentForRegister>();
            CreateMap<Resident,ResidentModelDto>();
        }
    }
}
