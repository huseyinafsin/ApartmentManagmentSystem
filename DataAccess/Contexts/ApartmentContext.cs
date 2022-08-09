using System.Threading;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entity.Concrete;
using DataAccess.Configuration;
using Entity.Concrete.MsSql;
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

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Status"] = true;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Status"] = false;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tenant>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<Password>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<Message>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<UserMessage>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<Flat>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<FlatType>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<Bill>().HasQueryFilter(x => x.Status == true);
            modelBuilder.Entity<BillType>().HasQueryFilter(x => x.Status == true);

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
