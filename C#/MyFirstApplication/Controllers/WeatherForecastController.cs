using Microsoft.AspNetCore.Mvc;
using MyFirstApplication;

namespace MyFirstApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        // Weather API
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

namespace MyFirstApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet(Name = "GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Ali", Department = "IT", Salary = 50000 },
                new Employee { Id = 2, Name = "Ahmed", Department = "HR", Salary = 40000 },
                new Employee { Id = 3, Name = "Sara", Department = "Finance", Salary = 60000 }
            };
        }
    }
}