using AutoMapper;
using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Concrete.Apartment.Bill;
using Dto.Concrete.Apartment.Flat;
using Dto.Concrete.Apartment.Tenant;
using Dto.Concrete.CreditCard;
using Dto.Concrete.Dtos.Bill;
using Dto.Concrete.Dtos.Flat;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;
using Entity.Mongo;

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

            CreateMap<Tenant, TenantModelDto>()
                .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id))
                .ForMember(x => x.IdentityNumber, cd => cd.MapFrom(map => map.IdentityNumber))
                .ForMember(x => x.Firstname, cd => cd.MapFrom(map => map.User.Firstname))
                .ForMember(x => x.Lastname, cd => cd.MapFrom(map => map.User.Lastname))
                .ForMember(x => x.Email, cd => cd.MapFrom(map => map.User.Email))
                .ForMember(x => x.Phone, cd => cd.MapFrom(map => map.Phone))
                .ForMember(x => x.InitialPassword, cd => cd.MapFrom(map => map.User.Pasword.InitialPassword))
                .ForMember(x => x.HasACar, cd => cd.MapFrom(map => map.HasACar))
                .ForMember(x => x.Plate, cd => cd.MapFrom(map => map.Plate))
                .ForMember(x => x.UserId, cd => cd.MapFrom(map => map.UserId))
                .ForMember(x => x.FlatId, cd => cd.MapFrom(map => map.FlatId))
                .ReverseMap();



            CreateMap<User, UserModel>()
                .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id))
                .ForMember(x => x.Firstname, cd => cd.MapFrom(map => map.Firstname))
                .ForMember(x => x.Lastname, cd => cd.MapFrom(map => map.Lastname));

            CreateMap<Flat, FlatModelDto>()
                .ForMember(x => x.Id, cd => cd.MapFrom(map => map.Id))
                .ForMember(x => x.Block, cd => cd.MapFrom(map => map.Block))
                .ForMember(x => x.FlatType, cd => cd.MapFrom(map => map.FlatType))
                .ForMember(x => x.Floor, cd => cd.MapFrom(map => map.Floor))
                .ForMember(x => x.IsInUse, cd => cd.MapFrom(map => map.IsInUse))
                .ForMember(x => x.MonthlyPrice, cd => cd.MapFrom(map => map.MonthlyPrice))
                .ForMember(x => x.Number, cd => cd.MapFrom(map => map.Number))
                .ReverseMap();

            CreateMap<FlatCreateDto, Flat>()
                .ForMember(x => x.Block, cd => cd.MapFrom(map => map.Block))
                .ForMember(x => x.FlatTypeId, cd => cd.MapFrom(map => map.FlatTypeId))
                .ForMember(x => x.Floor, cd => cd.MapFrom(map => map.Floor))
                .ForMember(x => x.MonthlyPrice, cd => cd.MapFrom(map => map.MonthlyPrice))
                .ForMember(x => x.Number, cd => cd.MapFrom(map => map.Number))
                .ForMember(x => x.IsInUse, cd => cd.MapFrom(map => false));

            CreateMap<Bill, BillModelDto>()
                .ForMember(x => x.Firstname, cd => cd.MapFrom(map => map.Tenant.User.Firstname))
                .ForMember(x => x.Lastname, cd => cd.MapFrom(map => map.Tenant.User.Lastname))
                .ForMember(x => x.Email, cd => cd.MapFrom(map => map.Tenant.User.Email))
                .ForMember(x => x.Phone, cd => cd.MapFrom(map => map.Tenant.Phone))
                .ForMember(x => x.IdentityNumber, cd => cd.MapFrom(map => map.Tenant.IdentityNumber))
                .ForMember(x => x.Amount, cd => cd.MapFrom(map => map.Amount))
                .ForMember(x => x.BillType, cd => cd.MapFrom(map => map.BillType.Name))
                .ForMember(x => x.Paid, cd => cd.MapFrom(map => map.Paid))
                .ForMember(x => x.Paid, cd => cd.MapFrom(map => map.Paid))
                .ReverseMap();

            CreateMap<BillCreateDto, Bill>();
            CreateMap<CreditCardDto, CreditCard>()
                .ReverseMap();
        


        }
    }
}
