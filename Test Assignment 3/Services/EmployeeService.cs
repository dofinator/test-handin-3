using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.Services
{
    public interface IEmployeeService
    {
        public Task<bool> CreateEmployee(CreateEmployeeDto createEmployeeDto);
        public Task<Employee> GetEmployeeById(int employeeId);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeService(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createEmployeeDto"></param>
        /// <returns></returns>
        public async Task<bool> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                await _employeeStorage.CreateEmployee(new Employee
                {
                    Birthday = createEmployeeDto.Birthday,
                    FirstName = createEmployeeDto.FirstName,
                    LastName = createEmployeeDto.LastName,
                    PhoneNumber = !String.IsNullOrEmpty(createEmployeeDto.PhoneNumber) ? createEmployeeDto.PhoneNumber : null,
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _employeeStorage.GetEmployeeById(employeeId);
        }
    }
}