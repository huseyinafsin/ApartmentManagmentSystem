using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Bussiness.Concrete.Apartment;
using Bussiness.Configuration.Mapper;
using Core.Entity.Concrete;
using Core.Repository;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Dtos.Tenant;
using Entity.Concrete.MsSql;
using Moq;
using Xunit;

namespace ApartmentManagmentTest
{
    public class TenantServiceTest 
    {
        

        public void TenantService_Create_Returns_Success()
        {
            #region Arrange
            var tenantRepositoryMock = new Mock<ITenatRepository>();
            tenantRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Tenant>()));

            var reapositoryMock = new Mock<IRepository<Tenant>>();

            var operationClaimServiceMock = new Mock<IOperationClaimService>();


            MapperConfiguration mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
            IMapper mapper = new Mapper(mapperConfig);
            #endregion

            #region Act

            var tenantService = new TenantService(reapositoryMock.Object,tenantRepositoryMock.Object,mapper,operationClaimServiceMock.Object);
            var tenant = new TenantCreateDto()
            {

                FlatId = 1,
                UserId = 1,
                HasACar = true,
                Phone = "665655356",
                IdentityNumber = "454545454",
                Plate = "365456464",

            };
            //var response = tenantService.AddTenant(tenant)

            #endregion

            #region Assert



            #endregion
        }


    }
}
