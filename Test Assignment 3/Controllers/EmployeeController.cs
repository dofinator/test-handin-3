using Microsoft.AspNetCore.Mvc;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Services;

namespace Test_Assignment_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService; 

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<bool> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            return await _employeeService.CreateEmployee(createEmployeeDto);
        }
    }
}