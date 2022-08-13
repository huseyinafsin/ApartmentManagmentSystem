using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagmentTest.Fixture;
using AutoMapper;
using Bussiness.Abstracts.Apartment;
using Bussiness.Concrete.Apartment;
using Bussiness.Configuration.Mapper;
using Core.Entity.Concrete;
using Core.Repository;
using DataAccess.Abstract.Apartment;
using Dto.Concrete.Dtos.Tenant;
using Dto.Concrete.User;
using Entity.Concrete.MsSql;
using Moq;
using Xunit;

namespace ApartmentManagmentTest 
{
    public class TenantServiceTest :IClassFixture<ServiceFixture>
    {
        private TenantService TenantService;
        public TenantServiceTest(ServiceFixture serviceFixture)
        {
            TenantService = new TenantService(serviceFixture.TenantRepositoryMock.Object, serviceFixture.TenantRepositoryMock.Object,serviceFixture.Mapper,serviceFixture.OperationClaimServiceMock.Object);
        }
        
        [Fact]
        public void TenantDelete_ReturnsSuccessTest( )
        {
            

            var tenant = new TenantForRegister()
            {
                IdentityNumber = "16515525",
                Email = "huseyinafssin@mail.com",
                Firstname = "Hüseyin",
                Lastname = "Afşin",
                FlatId = 1,
                HasACar = true,
                Phone = "665655356",
                Plate = "365456464",

            };
            var response = TenantService.AddTenant(tenant).Result;


            #region Assert

            Assert.Equal(response.Success,true);
            #endregion
        }
              
        
        [Fact]
        public void TenantGetAll_ReturnsSuccessTest( )
        {

            var response = TenantService.RemoveAsync(1).Result;


            #region Assert

            Assert.Equal(response.Success,true);
            Assert.NotNull(response);
            #endregion
        }
                
        [Fact]
        public void TenantCreate_ReturnsSuccessTest( )
        {

            var response = TenantService.RemoveAsync(1).Result;


            #region Assert

            Assert.Equal(response.Success,true);
            Assert.Equal(response.Success,true);
            #endregion
        }


    }
}
