using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
