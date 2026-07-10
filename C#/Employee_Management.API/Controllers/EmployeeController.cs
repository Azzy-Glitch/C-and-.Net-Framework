using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //GLOBAL LIST
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ali", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Ahmed", Department = "HR", Salary = 40000 },
            new Employee { Id = 3, Name = "Sara", Department = "Finance", Salary = 60000 }
        };

        // GET: api/Employee
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return employees;
        }

        // GET: api/Employee/single
        [HttpGet("single")]
        public Employee GetEmployee()
        {
            return employees.FirstOrDefault();
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        // GET: api/Employee/name/Ali
        [HttpGet("name/{name}")]
        public List<Employee> GetEmployeeByName(string name)
        {
            return employees
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
    }
}

//namespace Employee_Management.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        // GET: api/Employee
//        [HttpGet]
//        public List<Employee> GetEmployees()
//        {
//            List<Employee> employee = new List<Employee>();

//            employee.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employee.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employee.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            return employee;
//        }

//        // GET: api/Employee/single
//        [HttpGet("single")]
//        public Employee GetEmployee()
//        {
//            return new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            };
//        }

//        // GET: api/Employee/1
//        [HttpGet("{id}")]
//        public Employee GetEmployeeById(int id)
//        {
//            var employees = new List<Employee>();

//            employees.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employees.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employees.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            return employees.FirstOrDefault(x => x.Id == id);
//        }

//        // GET: api/Employee/name/Ali
//        [HttpGet("name/{name}")]
//        public List<Employee> GetEmployeeByName(string name)
//        {
//            var employees = new List<Employee>();

//            employees.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employees.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employees.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            // Case-insensitive search
//            return employees
//                .Where(x => x.Name.ToLower() == name.ToLower())
//                .ToList();
//        }
//    }
//}