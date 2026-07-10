using System;
using System.Text.Json;
using Class_3;

string jsonData = @"[
     { ""id"": 1, ""name"": ""Ali"", ""department"": ""IT"", ""salary"": 85000, ""age"": 28, ""city"": ""Rawalpindi"" },
     { ""id"": 2, ""name"": ""Ahmed"", ""department"": ""HR"", ""salary"": 55000, ""age"": 31, ""city"": ""Islamabad"" },
     { ""id"": 3, ""name"": ""Sara"", ""department"": ""IT"", ""salary"": 95000, ""age"": 26, ""city"": ""Lahore"" },
     { ""id"": 4, ""name"": ""Ayesha"", ""department"": ""Finance"", ""salary"": 70000, ""age"": 35, ""city"": ""Rawalpindi"" },
     { ""id"": 5, ""name"": ""Bilal"", ""department"": ""IT"", ""salary"": 60000, ""age"": 24, ""city"": ""Islamabad"" },
     { ""id"": 6, ""name"": ""Fatima"", ""department"": ""HR"", ""salary"": 65000, ""age"": 29, ""city"": ""Lahore"" }
 ]";

 List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);


var highSalary = employees.Where(e => e.salary > 70000);

Console.WriteLine("Employees with Salary > 70000:");
foreach (var e in highSalary)
{
    Console.WriteLine($"{e.name} , {e.salary}");
}

var itEmployees = employees.Where(e => e.department == "IT");

Console.WriteLine("Employees in IT Department:");
foreach (var e in itEmployees)
{
    Console.WriteLine($"{e.name} , {e.department}");
}

