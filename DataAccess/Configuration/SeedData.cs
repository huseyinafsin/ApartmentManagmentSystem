using Bogus;
using Core.Abstract;
using Core.Entity.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public static class SeedData
    {
        public static int Ids { get; set; } = 1;


        public static void SeedBill(this ModelBuilder modelBuilder)
        {
            Faker<Bill> faker = new Faker<Bill>()
                .RuleFor(r => r.Id, f => Ids++);
            List<Bill> data = faker.Generate(100);
            modelBuilder.Entity<Bill>().HasData(data);
        }


        public static void SeedBillType(this ModelBuilder modelBuilder)
        {
            Faker<BillType> faker = new Faker<BillType>()
                .RuleFor(r => r.Id, f => Ids++);
            List<BillType> data = faker.GenerateBetween(100, 100);
            modelBuilder.Entity<BillType>().HasData(data);
        }


        public static void SeedFlat(this ModelBuilder modelBuilder)
        {
            Faker<Flat> faker = new Faker<Flat>()
                .RuleFor(r => r.Id, f => Ids++);
            List<Flat> data = faker.Generate(100);
            modelBuilder.Entity<Flat>().HasData(data);
        }


        public static void SeedFlatType(this ModelBuilder modelBuilder)
        {
            Faker<FlatType> faker = new Faker<FlatType>()
                .RuleFor(r => r.Id, f => Ids++);

            List<FlatType> data = faker.Generate(100);
            modelBuilder.Entity<FlatType>().HasData(data);
        }


        public static void SeedMessage(this ModelBuilder modelBuilder)
        {
            Faker<Message> faker = new Faker<Message>()
                .RuleFor(r => r.Id, f => Ids++);

            List<Message> data = faker.Generate(100);
            modelBuilder.Entity<Message>().HasData(data);
        }


        public static void SeedManager(this ModelBuilder modelBuilder)
        {
            Faker<Manager> faker = new Faker<Manager>()
                .RuleFor(r => r.Id, f => Ids++);
            List<Manager> data = faker.Generate(1);
            modelBuilder.Entity<Manager>().HasData(data);
        }


        public static void SeedPaymentType(this ModelBuilder modelBuilder)
        {
            Faker<PaymentType> faker = new Faker<PaymentType>()
                .RuleFor(r => r.Id, f => Ids++);
            List<PaymentType> data = faker.Generate(1);
            modelBuilder.Entity<PaymentType>().HasData(data);
        }


        public static void SeedResident(this ModelBuilder modelBuilder)
        {
            Faker<Tenant> faker = new Faker<Tenant>()
                .RuleFor(r => r.Id, f => Ids++);
            List<Tenant> data = faker.Generate(100);
            modelBuilder.Entity<Tenant>().HasData(data);
        }

        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            Faker<User> faker = new Faker<User>()
                .RuleFor(r => r.Id, f => Ids++);
            List<User> data = faker.Generate(100);
            modelBuilder.Entity<User>().HasData(data);
        }

        public static void SeedUserMessage(this ModelBuilder modelBuilder)
        {
            Faker<UserMessage> faker = new Faker<UserMessage>()
                .RuleFor(r => r.Id, f => Ids++);
            List<UserMessage> data = faker.Generate(100);
            modelBuilder.Entity<UserMessage>().HasData(data);
        }



    }
}
