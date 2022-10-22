using Test_Assignment_3.Context;
using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Models;

namespace Test.IntegrationTest
{
    public class IntegrationTesting
    {

        [SetUp]
        public void Setup()
        {
        }

        DBApplicationContext CreateContext() => SetupInMemoryDatabase.CreateContextForInMemory();

        #region CustomerStorage
        [Test]
        public async Task GetCustomerById_Should_Return_Customer()
        {
            //Arrange
            using var context = CreateContext();
            var customerStorage = new CustomerStorage(context);

            //Act
            var customer = await customerStorage.GetCustomerById(1);
            var expectedName = "Phillip";

            //Assert
            Assert.That(customer.FirstName, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task CreateCustomer_Should_Create_Customer()
        {
            //Arrange
            using var context = CreateContext();
            var customerStorage = new CustomerStorage(context);

            //Act
            var isCreated = await customerStorage.CreateCustomer(new Customer
            {
                id = 4,
                FirstName = "Phillip2",
                LastName = "Deey2",
                Birthday = DateTime.UtcNow
            });

            var expected = true;

            //Assert
            Assert.That(isCreated, Is.EqualTo(expected));
        }

        #endregion CustomerStorage


        #region EmployeeStorage

        [Test]
        public async Task GetEmployeeById_Should_Return_Employee()
        {
            //Arrange
            using var context = CreateContext();
            var employeeStorage = new EmployeeStorage(context);

            //Act
            var employee = await employeeStorage.GetEmployeeById(1);
            var expectedName = "Phillip";

            //Assert
            Assert.That(employee.FirstName, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task CreeateEmployee_Should_Create_Employee()
        {
            //Arrange
            using var context = CreateContext();
            var employeeStorage = new EmployeeStorage(context);

            //Act
            var isCreated = await employeeStorage.CreateEmployee(new Employee
            {
                id = 4,
                FirstName = "Phillip",
                LastName = "Deey",
                Birthday = DateTime.UtcNow
            });

            var expected = true;

            //Assert
            Assert.That(isCreated, Is.EqualTo(expected));
        }

        #endregion EmployeeStorage

        #region BookingStorage
        [Test]
        public async Task CreateBooking_Should_Create_Booking()
        {
            //Arrange
            using var context = CreateContext();
            var bookingStorage = new BookingStorage(context);

            //Act
            var isCreated = await bookingStorage.CreateBooking(
                new Booking
                {
                    id = 4,
                    CustomerId = 1,
                    Start = DateTime.UtcNow,
                    Date = DateTime.UtcNow,
                    End = DateTime.UtcNow.AddDays(2),
                    EmployeeId = 1
                });

            var expected = true;

            //Assert
            Assert.That(isCreated, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetBookingsForCustomerId_Should_Return_List_Of_Bookings()
        {
            //Arrange
            using var context = CreateContext();
            var bookingStorage = new BookingStorage(context);

            //Act
            var bookings = await bookingStorage.GetBookingsForCustomerId(2);
            var expectedCount = 1;

            //Assert
            Assert.That(bookings.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetBookingsForEmployeeId_Should_Return_List_Of_Bookings()
        {
            //Arrange
            using var context = CreateContext();
            var bookingStorage = new BookingStorage(context);

            //Act
            var bookings = await bookingStorage.GetBookingsForEmployeeId(3);
            var expectedCount = 1;

            //Assert
            Assert.That(bookings.Count, Is.EqualTo(expectedCount));
        }

        #endregion BookingStorage
    }
}


