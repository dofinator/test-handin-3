using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Assignment_3.Models
{
    public class Booking
    {
        public int id { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End { get; set; }

    }
}
