using System.ComponentModel.DataAnnotations;

namespace Test_Assignment_3.Dto
{
    public class CreateBookingDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
