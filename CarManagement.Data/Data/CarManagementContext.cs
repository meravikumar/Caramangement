using CarManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Data.Context
{
    public class CarManagementContext : DbContext
    {
        public CarManagementContext(DbContextOptions<CarManagementContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CarDetails> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car {CarId=1,CarName = "Kia seltos", CarModel = "Alpha", Price = 14, Insurance = true, CompanyId = 1 },
                new Car { CarId = 2, CarName = "Kia seltos", CarModel = "Alpha", Price = 14, Insurance = true, CompanyId = 1 },
                new Car { CarId = 3,CarName = "Kia seltos", CarModel = "Alpha", Price = 14, Insurance = true, CompanyId = 1 }

                );

            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId=1, CompanyName = "Kia", CEO = "Ravi sharma", Location = "Spain", EstablishedDate =new DateOnly(2020, 1, 1),IsFinanceProvider=true }
                );
        }
    }
}
