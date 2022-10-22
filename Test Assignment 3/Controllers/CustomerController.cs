using Microsoft.AspNetCore.Mvc;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Services;

namespace Test_Assignment_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerSerivce;

        public CustomerController(ICustomerService customerSerivce)
        {
            _customerSerivce = customerSerivce; 
        }

        [HttpPost]
        public async Task<bool> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            return await _customerSerivce.CreateCustomer(createCustomerDto);
        }
    }
}