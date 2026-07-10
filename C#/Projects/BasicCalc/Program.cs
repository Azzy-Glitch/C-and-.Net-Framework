using System;

double number1 = 0;
double number2 = 0;

Console.Write("Enter the first number: ");
number1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the second number: ");
number2 = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter an operator (+, -, *, /): ");
char op = Console.ReadLine()[0];

switch (op)
{
    case '+':
        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
        break;
    case '-':
        Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
        break;
    case '*':
        Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
        break;
    case '/':
        if (number2 != 0)
            Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
        else
            Console.WriteLine("Error: Division by zero is not allowed.");
        break;
    default:
        Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
        break;
}