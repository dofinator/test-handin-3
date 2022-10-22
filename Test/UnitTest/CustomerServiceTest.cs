using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data;
using System.Dynamic;
using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;
using Test_Assignment_3.Services;

namespace Test.UnitTest
{
    public class CustomerServiceTest
    {

        private Mock<ICustomerStorage> _customerStorageMock;
        private ICustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            _customerStorageMock = new Mock<ICustomerStorage>();
            _customerService = new CustomerService(_customerStorageMock.Object);

        }

        [Test]
        public async Task CreateCustomer_Should_Create_Customer()
        {
            //Arrange
            var newCustomer = new CreateCustomerDto { FirstName = "John", LastName = "Doe" };
            _customerStorageMock.Setup(_ => _.CreateCustomer(new Customer { })).ReturnsAsync(false);

            //Act
            var actualMocked = await _customerService.CreateCustomer(newCustomer);
            var expected = false;

            //Assert
            Assert.That(actualMocked, Is.EqualTo(expected));

        }


        [Test]
        public async Task GetCustomerById_Should_Return_Customer()
        {
            //Arrange
            var testCustomer = new Customer { id = 2, FirstName = "Kristoffer", LastName = "Wegner" };
            _customerStorageMock.Setup(_ => _.GetCustomerById(2)).ReturnsAsync(testCustomer);

            //Act
            var actualMocked = await _customerService.GetCustomerById(2);
            var expected = testCustomer;

            //Assert
            Assert.That(actualMocked.FirstName, Is.EqualTo(expected.FirstName));

        }

    }
}