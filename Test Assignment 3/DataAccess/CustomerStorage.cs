using Test_Assignment_3.Context;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.DataAccess
{
    public interface ICustomerStorage
    {
        public Task<Customer> GetCustomerById(int customerId);
        public Task<bool> CreateCustomer(Customer customer);
    }
    public class CustomerStorage : ICustomerStorage
    {
        private readonly DBApplicationContext _dbContext;

        public CustomerStorage(DBApplicationContext dBApplicationContext)
        {
            _dbContext = dBApplicationContext;
        }

        /// <summary>
        /// Creates a customer and saves it in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<bool> CreateCustomer(Customer customer)
        {
            try
            {
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
           return await _dbContext.Customers.FindAsync(customerId);   
        }
    }
}
