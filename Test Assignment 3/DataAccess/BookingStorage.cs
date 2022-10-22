using Microsoft.EntityFrameworkCore;
using Test_Assignment_3.Context;
using Test_Assignment_3.Models;

namespace Test_Assignment_3.DataAccess
{
    public interface IBookingStorage
    {
        public Task<bool> CreateBooking(Booking booking);
        public Task<List<Booking>> GetBookingsForCustomerId(int customerId);
        public Task<List<Booking>> GetBookingsForEmployeeId(int employeeId);
        public void SendSms(Booking booking);
    }

    public class BookingStorage : IBookingStorage
    {
        private readonly DBApplicationContext _dbContext;

        public BookingStorage(DBApplicationContext dBApplicationContext)
        {
            _dbContext = dBApplicationContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task<bool> CreateBooking(Booking booking)
        {
            try
            {
                await _dbContext.Bookings.AddAsync(booking);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<Booking>> GetBookingsForCustomerId(int customerId)
        {
            return await _dbContext.Bookings.
                Include(_ => _.Customer).
                Include(_ => _.Employee).
                Where(_ => _.Customer.id == customerId)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<List<Booking>> GetBookingsForEmployeeId(int employeeId)
        {
            return await _dbContext.Bookings.
               Include(_ => _.Customer).
               Include(_ => _.Employee).
               Where(_ => _.Employee.id == employeeId)
               .ToListAsync();
        }

        public void SendSms(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}