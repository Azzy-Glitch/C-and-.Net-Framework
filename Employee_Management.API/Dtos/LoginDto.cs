using Employee_Management.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Dtos
{
    public class LoginDto: Identity
    {
        [EmailAddress]
        public required string DEmail { get; set; }

        [RegularExpression(@"^[A-Z].{7,}$",
            ErrorMessage = "Password must start with a capital letter and be at least 8 characters long.")]
        public required string DPassword { get; set; }
    }
}