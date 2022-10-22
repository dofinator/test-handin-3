namespace Test_Assignment_3.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Booking>  Bookings { get; set; } = new List<Booking>();
    }
}
