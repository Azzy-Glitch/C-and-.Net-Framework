using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public List<Login> users = new List<Login>();

        [HttpGet("UserData")]

        public List<Login> GetUsers()
        {
            if (users.Count == 0)
            {
                return new List<Login>();
            }

            return users;
        }

        [HttpPost("UserData")]
        public IActionResult AddUser(Login user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid user data.");
            }
            users.Add(user);
            return Ok("User added successfully.");
        }
    }
}
