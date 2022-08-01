using AutoMapper;
using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Concrete.Dtos.Flat;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete;

namespace Bussiness.Configuration.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ManagerForRegister>();
            CreateMap<Manager, ManagerForRegister>();
            CreateMap<User, TenantForRegister>();
            CreateMap<Tenant, TenantForRegister>();
            CreateMap<Tenant, TenantModelDto>();


            CreateMap<Flat, FlatDetailModelDto>()
                .ForMember(x => x.Block, cd => cd.MapFrom(map => map.Block))
                .ForMember(x => x.FlatType, cd => cd.MapFrom(map => map.FlatType.Type))
                .ForMember(x => x.Floor, cd => cd.MapFrom(map => map.Floor))
                .ForMember(x => x.IsInUse, cd => cd.MapFrom(map => map.IsInUse))
                .ForMember(x => x.MonthlyPrice, cd => cd.MapFrom(map => map.MonthlyPrice))
                .ForMember(x => x.Number, cd => cd.MapFrom(map => map.Number))
                .ForMember(x => x.TenantFirstname, cd => cd.MapFrom(map => map.Tenant.User.Firstname))
                .ForMember(x => x.TenantLastname, cd => cd.MapFrom(map => map.Tenant.User.Lastname));
        }
    }
}
