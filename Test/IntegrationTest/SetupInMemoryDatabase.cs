using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Assignment_3.Context;
using Microsoft.Data.Sqlite;
using Test_Assignment_3.Models;

namespace Test.IntegrationTest
{
    public class SetupInMemoryDatabase : IDisposable
    {
        private bool disposedValue = false; // To detect redundant calls

        public static DBApplicationContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<DBApplicationContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new DBApplicationContext(option);
            if (context != null)
            {
                var customer1 = new Customer { id = 1, FirstName = "Phillip", LastName = "Deey", Birthday = DateTime.UtcNow };
                var customer2 = new Customer { id = 2, FirstName = "Summit", LastName = "CodMap", Birthday = DateTime.UtcNow };
                var customer3 = new Customer { id = 3, FirstName = "KridtStoffer", LastName = "PythonTaber", Birthday = DateTime.UtcNow };

                var employee1 = new Employee { id = 1, FirstName = "Phillip", LastName = "Deey", Birthday = DateTime.UtcNow };
                var employee2 = new Employee { id = 2, FirstName = "Summit", LastName = "CodMap", Birthday = DateTime.UtcNow };
                var employee3 = new Employee { id = 3, FirstName = "KridtStoffer", LastName = "PythonTaber", Birthday = DateTime.UtcNow };

                var booking1 = new Booking { id = 1, Customer = customer1, Start = DateTime.UtcNow, Date = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(2), Employee = employee1 };
                var booking2 = new Booking { id = 2, Customer = customer2, Start = DateTime.UtcNow, Date = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(2), Employee = employee2 };
                var booking3 = new Booking { id = 3, Customer = customer3, Start = DateTime.UtcNow, Date = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(2), Employee = employee3 };

                // Customers
                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
                context.Customers.Add(customer3);

                // Employees
                context.Employees.Add(employee1);
                context.Employees.Add(employee2);
                context.Employees.Add(employee3);

                // Bookings
                context.Bookings.Add(booking1);
                context.Bookings.Add(booking2);
                context.Bookings.Add(booking3);


                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Save
                context.SaveChanges();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
