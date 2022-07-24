using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts
{
    public class ApartmentContext : DbContext
    {
        private IConfiguration _configuration;

        public ApartmentContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnectionString");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }

    }
}
