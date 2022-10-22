using Microsoft.EntityFrameworkCore;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.Context
{
    public class DBApplicationContext : DbContext
    {
        public DBApplicationContext(DbContextOptions<DBApplicationContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);
            base.OnModelCreating(builder);
        }
        private static void Seed(ModelBuilder builder)
        {
            //builder.Entity<Customer>().Property(u => u.Birthday).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Employee>().Property(_ => _.PhoneNumber).IsRequired(false);
            //builder.Entity<Customer>().HasData(new Customer { id = 1, FirstName = "SD", LastName = "DS", Birthday = DateTime.UtcNow });
        }
    }
}

