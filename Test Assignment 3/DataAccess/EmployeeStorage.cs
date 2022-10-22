using Test_Assignment_3.Context;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.DataAccess
{
    public interface IEmployeeStorage
    {
        public Task<Employee> GetEmployeeById(int employeeId);
        public Task<bool> CreateEmployee(Employee employee);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly DBApplicationContext _dbContext;

        public EmployeeStorage(DBApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> CreateEmployee(Employee employee)
        {
            try
            {
                await _dbContext.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a employee by employee id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _dbContext.Employees.FindAsync(employeeId);
        }
    }
}