using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class EmployeeDto
    {
        [Required]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string phonenumber { get; set; }
        public required string Department { get; set; }
        public double Salary { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}