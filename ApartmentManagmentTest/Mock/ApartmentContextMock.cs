using System;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApartmentManagmentTest.Mock
{
    public class ApartmentContextMock : ApartmentContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }

        public ApartmentContextMock(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
