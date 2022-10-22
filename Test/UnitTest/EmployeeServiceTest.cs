using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Dynamic;
using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;
using Test_Assignment_3.Services;

namespace Test.UnitTest
{
    public class EmployeeServiceTest
    {

        private Mock<IEmployeeStorage> _employeeStorageMock;
        private IEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeStorageMock = new Mock<IEmployeeStorage>();
            _employeeService = new EmployeeService(_employeeStorageMock.Object);
        }

        [Test]
        public async Task GetEmployeeById_Should_Return_Employee()
        {
            //Arrange
            var testEmployee = new Employee { id = 2, FirstName = "Sumit", LastName = "Dey" };
            _employeeStorageMock.Setup(_ => _.GetEmployeeById(2)).ReturnsAsync(testEmployee);

            //Act
            var actualMocked = await _employeeService.GetEmployeeById(2);
            var expected = testEmployee;

            //Assert
            Assert.That(actualMocked.FirstName, Is.EqualTo(expected.FirstName));

        }
        [Test]
        public async Task CreateEmployee_Should_Create_Employee()
        {
            //Arrange
            var newEmployee = new CreateEmployeeDto {FirstName = "Phillip", LastName = "Andersen" };
            _employeeStorageMock.Setup(_ => _.CreateEmployee(new Employee { })).ReturnsAsync(true);

            //Act
            var actualMocked = await _employeeService.CreateEmployee(newEmployee);
            var expected = true;

            //Assert
            Assert.That(actualMocked, Is.EqualTo(expected));
        }

    }
}