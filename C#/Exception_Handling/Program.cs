int a = 0;
int b = 0;

Console.Write("Enter First Number: ");
a = int.Parse(Console.ReadLine());

Console.Write("Enter Second Number: ");
b = int.Parse(Console.ReadLine());

try
{
    int c = a / b;
    Console.WriteLine($"Result: {c}");
}
catch(DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
finally
{
    Console.WriteLine("Program Ended...");
}