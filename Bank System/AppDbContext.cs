using Bank_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BankSystem;Trusted_Connection=True;TrustServerCertificate=True;");
            
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // SEEDING ...

            modelBuilder.Entity<Manager>(ETB =>
            ETB.HasData(
                 new Manager
                 {
                     Id = 1,
                     FullName = "Ahmad Yahia",
                     Email = "Yahia@Mail.com",
                     PhoneNumber = 0123456654,
                     HireDate = DateOnly.Parse("10/10/2020")
                 },
                new Manager
                {
                    Id = 2,
                    FullName = "Mohmad Magdy",
                    Email = "Magdy@Mail.com",
                    PhoneNumber = 0123456654,
                    HireDate = DateOnly.Parse("09/08/2018")
                }

                )

            );


            modelBuilder.Entity<Branch>(ETB =>
            ETB.HasData(
                 new Branch
                 {
                     Code = "CAI-01",
                     Name = "Main Branch",
                     Address = "123-Cairo-Egypt",
                     PhoneNumber = 01234667897,
                     ManagerId = 1
                 },
                new Branch
                {
                    Code = "CAI-02",
                    Name = "Secondary Branch",
                    Address = "123-Cairo-Egypt",
                    PhoneNumber = 01234667897,
                    ManagerId = 2
                }
                    ));


        }
        internal  DbSet<Manager> Managers { get; set; }
        internal DbSet<Branch> Branches { get; set; }
        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<CustomerAccount> CustomerAccount { get; set; }
        internal DbSet<Transaction> Transactions { get; set; }


    }
}
