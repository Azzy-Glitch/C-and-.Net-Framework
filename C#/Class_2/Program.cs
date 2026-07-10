using Class_2;

List<Employee> employee = new List<Employee>();

employee.Add(new Employee
{
    Name = "Azzy",
    Department = "IT",
    Salary = 90
});

employee.Add(new Employee
{
    Name = "Ramil",
    Department = "Teacher",
    Salary = 9000
});

employee.Add(new Employee
{
    Name = "Glitch",
    Department = "Error",
    Salary = 90001
});

//var EmployeeInfo = employee.Where(x => x.Name == "Azzy").Select(employee => new
//{
//    employee.Name,
//    employee.Department,
//    employee.Salary
//}).FirstOrDefault();

//Console.WriteLine(EmployeeInfo);

var EmployeeInfo = employee.Select(employee => new
{
    employee.Name,
    employee.Department,
    employee.Salary
}).OrderByDescending(x => x.Salary);

foreach (var Emp in EmployeeInfo)
{
    Console.WriteLine(Emp);
}

var MinSalary = employee.Min(x => x.Salary);
Console.WriteLine(MinSalary);

var SumSalary = employee.Sum(x => x.Salary);
Console.WriteLine(SumSalary);

var AvgSalary = employee.Average(x => x.Salary);
Console.WriteLine(AvgSalary);

var MaxSalary = employee.Max(x => x.Salary);
Console.WriteLine(MaxSalary);
