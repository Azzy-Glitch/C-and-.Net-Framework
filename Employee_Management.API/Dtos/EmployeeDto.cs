using Employee_Management.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class EmployeeDto: Identity
    {
        public required string DName { get; set; }
        [RegularExpression(@"^(\+92|0)3\d{9}$", ErrorMessage = "Phone number must start with 03 and be 11 digits.")]
        public required string DPhoneNumber { get; set; }
        public required string DDepartment { get; set; }
        public required string DDesignation { get; set; }
        public required double DSalary { get; set; }
        [EmailAddress]
        public required string DEmail { get; set; }
    }
}