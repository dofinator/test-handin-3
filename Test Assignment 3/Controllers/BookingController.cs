using Microsoft.AspNetCore.Mvc;
using Test_Assignment_3.Dto;
using Test_Assignment_3.Models;
using Test_Assignment_3.Services;

namespace Test_Assignment_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<bool> CreaeteBookingDto(CreateBookingDto createBookingDto)
        {
            return await _bookingService.CreateBooking(createBookingDto);
        }

        [HttpGet("{customerId}")]
        public async Task<List<Booking>> GetBookingsByCustomer(int customerId)
        {
            return await _bookingService.GetBookingsForCustomerId(customerId);
        }

        [HttpGet("{employeeId}")]
        public async Task<List<Booking>> GetBookingsByEmployee(int employeeId)
        {
            return await _bookingService.GetBookingsForEmployeeId(employeeId);
        }
    }
}