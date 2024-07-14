using DistributedCache.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DistributedCache.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedCustomers(modelBuilder);
        }

        private static void SeedCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x =>
            {
                x.HasData(new Customer
                {
                    Id = 1,
                    Name="John",
                    Street="Main Street",
                    City="Manchester",
                    State="CT",
                    Zipcode="0602",
                    Email="john@email.com",
                    Phone="999-333-2352"
                });
                x.HasData(new Customer
                {
                    Id = 2,
                    Name = "Rajj",
                    Street = "Main Street",
                    City = "Manchester",
                    State = "CT",
                    Zipcode = "06042",
                    Email = "rajj@email.com",
                    Phone = "999-334-2352"
                });
                x.HasData(new Customer
                {
                    Id = 3,
                    Name = "Paul",
                    Street = "Buckland Street",
                    City = "Manchester",
                    State = "CT",
                    Zipcode = "06042",
                    Email = "paul@email.com",
                    Phone = "999-333-2353"
                });
            });
        }
    }
}
