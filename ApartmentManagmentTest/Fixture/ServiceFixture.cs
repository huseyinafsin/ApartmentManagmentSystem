using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Bussiness.Configuration.Mapper;
using Core.Repository;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Apartment.Flat;
using Entity.Concrete.MsSql;
using Moq;

namespace ApartmentManagmentTest.Fixture
{
    public class ServiceFixture : IDisposable
    {
        public Mock<ITenatRepository> TenantRepositoryMock;
        public Mock<IRepository<Flat>> FlatRepositoryMock;

        public Mock<IOperationClaimService> OperationClaimServiceMock;
        public IMapper Mapper;
        public ServiceFixture()
        {
             TenantRepositoryMock = new Mock<ITenatRepository>();
             TenantRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Tenant>()));
             TenantRepositoryMock.Setup(x => x.Remove(It.IsAny<Tenant>()));
             TenantRepositoryMock.Setup(x => x.Update(It.IsAny<Tenant>()));


             //ReapositoryMock = new Mock<IRepository<Tenant>>();

             OperationClaimServiceMock = new Mock<IOperationClaimService>();


            MapperConfiguration mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
             Mapper  = new Mapper(mapperConfig);
         
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
