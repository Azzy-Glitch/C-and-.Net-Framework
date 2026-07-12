using Employee_Management.API.Dtos;
using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public static List<Login> users = new List<Login>();

        [HttpGet("UserData")]

        public List<Login> GetUsers()
        {
            if (users.Count == 0)
            {
                return new List<Login>();
            }

            return users;
        }

        [HttpPost("UserValidation")]
        public IActionResult AddUser(LoginDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var user = new Login
            {
                Email = dto.Email,
                Password = dto.Password
            };

            users.Add(user);

            return Ok("User added successfully.");
        }
    }
}
