using Employee_Management.API.Data;
using Employee_Management.API.Model;

public static class DbInitializer
{
    public static async Task SeedEmployees(EmployeeDbContext context)
    {
        if (context.Employees.Any())
            return;

        var employees = new List<Employee>
        {
            new Employee
            {
                Name = "Admin",
                Department = "IT",
                Designation = "Manager",
                Salary = 99090,
                Email = "admin@test.com"
            }
        };

        await context.Employees.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }
}