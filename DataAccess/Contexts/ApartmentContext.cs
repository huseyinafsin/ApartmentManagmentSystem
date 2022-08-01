using Core.Entity.Concrete;
using DataAccess.Configuration;
using Entity.Concrete;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.SeedBill();
            //modelBuilder.SeedBillType();
            //modelBuilder.SeedFlat();
            //modelBuilder.SeedFlatType();
            //modelBuilder.SeedManager();
            //modelBuilder.SeedMessage();
            //modelBuilder.SeedPaymentType();
            //modelBuilder.SeedResident();
            //modelBuilder.SeedUser();
            //modelBuilder.SeedUserMessage();
        }

        public virtual DbSet<Bill>  Bills { get; set; }
        public virtual DbSet<BillType>  BillTypes { get; set; }
        public virtual DbSet<Flat>  Flats { get; set; }
        public virtual DbSet<FlatType>  FlatTypes { get; set; }
        public virtual DbSet<Manager>  Managers { get; set; }
        public virtual DbSet<PaymentType>  PaymentTypes { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User>  Users { get; set; }
        public virtual DbSet<Message>  Messages { get; set; }
        public virtual DbSet<UserMessage>   UserMessages { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
