using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;
using Test_Assignment_3.Services;

namespace Test.UnitTest
{
    public class BookingServiceTest
    {
        private Mock<IBookingStorage> _bookingStorageMock;
        private Mock<IEmployeeStorage> _employeeStorageMock;
        private IBookingService _bookingService;
        private Mock<ICustomerStorage> _customerStorageMock;


        [SetUp]
        public void Setup()
        {
            _bookingStorageMock = new Mock<IBookingStorage>();
            _employeeStorageMock = new Mock<IEmployeeStorage>();
            _customerStorageMock = new Mock<ICustomerStorage>();
            _bookingService = new BookingService(
                _bookingStorageMock.Object,
                _employeeStorageMock.Object,
                _customerStorageMock.Object);
        }

        [Test]
        public async Task CreateBooking_Should_Return_Booking()
        {
            //Arrange
            var newBooking = new CreateBookingDto
            {
                EmployeeId = 1,
                CustomerId = 2
            };
            _bookingStorageMock.Setup(_ => _.CreateBooking(new Booking { })).ReturnsAsync(false);

            //Act
            var actualMocked = await _bookingService.CreateBooking(newBooking);
            var expected = false;

            //Assert
            Assert.That(actualMocked, Is.EqualTo(expected));

        }


        [Test]
        public async Task GetBookingsForCustomer_Should_Return_Bookinglist()
        {
            //Arrange
            _bookingStorageMock.Setup(_ => _.GetBookingsForCustomerId(1)).ReturnsAsync(GetFakeBookings());

            //Act
            var actualMocked = await _bookingService.GetBookingsForCustomerId(1);
            var expected = GetFakeBookings();

            //Assert
            Assert.That(actualMocked.Count, Is.EqualTo(expected.Count));



        }
        [Test]
        public async Task GetBookingsForEmployee_Should_Return_Bookinglist()
        {
            //Arrange
            _bookingStorageMock.Setup(_ => _.GetBookingsForEmployeeId(1)).ReturnsAsync(GetFakeBookings());

            //Act
            var actualMocked = await _bookingService.GetBookingsForEmployeeId(1);
            var expected = GetFakeBookings();

            //Assert
            Assert.That(actualMocked.Count, Is.EqualTo(expected.Count));



        }
        private List<Booking> GetFakeBookings()
        {
            return new List<Booking>
            {
                new Booking{}, new Booking{}
            };
        }
    }
}
