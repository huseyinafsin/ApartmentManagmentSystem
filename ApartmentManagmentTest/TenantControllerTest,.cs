using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagmentTest.Fixture;
using ApartmentManagmentSystem.Controllers;
using Bussiness.Concrete.Apartment;
using Dto.Concrete.User;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApartmentManagmentTest
{
    public class TenantControllerTest_ :IClassFixture<ServiceFixture>
    {
        public TenantService TenantService;

        public TenantController TenantController;
        public TenantControllerTest_(ServiceFixture serviceFixture)
        {
            TenantService = new TenantService(serviceFixture.TenantRepositoryMock.Object, serviceFixture.TenantRepositoryMock.Object, serviceFixture.Mapper, serviceFixture.OperationClaimServiceMock.Object);
            TenantController = new TenantController(TenantService, serviceFixture.Mapper);
        }


        [Fact]
        public void Get_WithoutParam_Ok_Test()
        {
            var tenant = new TenantForRegister() { };
            var result = TenantController.Post(tenant).Result as OkObjectResult;
            
            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Theory]
        [InlineData(0)]
        public void GetTenant_WithNonUser_ThenBadRequest_Test(int id)
        {
            var result = TenantController.Get(id).Result as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User not found!", result.Value);
        }
    }
}
