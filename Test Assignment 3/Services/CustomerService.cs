using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.Services
{
    public interface ICustomerService
    {
        public Task<bool> CreateCustomer(CreateCustomerDto createCustomerDto);
        public Task<Customer> GetCustomerById(int customerId);
    }


    public class CustomerService : ICustomerService
    {
        private readonly ICustomerStorage _customerStorage;

        public CustomerService(ICustomerStorage customerStorage)
        {
            _customerStorage = customerStorage;
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="createCustomerDto"></param>
        /// <returns></returns>
        public async Task<bool> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                return await _customerStorage.CreateCustomer(new Customer
                {
                    FirstName = createCustomerDto.FirstName,
                    LastName = createCustomerDto.LastName,
                    Birthday = createCustomerDto.Birthday,
                });
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _customerStorage.GetCustomerById(customerId);
        }
    }
}
