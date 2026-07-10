using System;

class Vehicle
{
    public string Brand;
    public string Model;
    public int Year;

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public void StartEngine()
    {
        Console.WriteLine("Engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Engine stopped.");
    }
}

class Car : Vehicle
{
    public int NumberOfDoors;

    public Car(string brand, string model, int year, int numberOfDoors)
        : base(brand, model, year)
    {
        NumberOfDoors = numberOfDoors;
    }

    public void OpenTrunk()
    {
        Console.WriteLine("Trunk opened.");
    }
}

class Bike : Vehicle
{
    public bool HasCarrier;

    public Bike(string brand, string model, int year, bool hasCarrier)
        : base(brand, model, year)
    {
        HasCarrier = hasCarrier;
    }

    public void RingBell()
    {
        Console.WriteLine("Bell rung.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of cars: ");
        int NumCars = int.Parse(Console.ReadLine());

        Car[] cars = new Car[NumCars];

        for (int i = 0; i < NumCars; i++)
        {
            Console.WriteLine($"\nEnter details for car {i + 1}:");

            Console.Write("Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Number of Doors: ");
            int doors = int.Parse(Console.ReadLine());

            cars[i] = new Car(brand, model, year, doors);
        }

        Console.Write("\nEnter the number of bikes: ");
        int NumBikes = int.Parse(Console.ReadLine());

        Bike[] bikes = new Bike[NumBikes];

        for (int i = 0; i < NumBikes; i++)
        {
            Console.WriteLine($"\nEnter details for bike {i + 1}:");

            Console.Write("Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Has Carrier (true/false): ");
            bool hasCarrier = bool.Parse(Console.ReadLine());

            bikes[i] = new Bike(brand, model, year, hasCarrier);
        }

        Console.WriteLine("\n--- Vehicle Details ---");

        Console.WriteLine("\nCars:");
        for (int i = 0; i < NumCars; i++)
        {
            Console.WriteLine($"Car {i + 1}: {cars[i].Brand} {cars[i].Model} ({cars[i].Year}), Doors: {cars[i].NumberOfDoors}");
        }

        Console.WriteLine("\nBikes:");
        for (int i = 0; i < NumBikes; i++)
        {
            Console.WriteLine($"Bike {i + 1}: {bikes[i].Brand} {bikes[i].Model} ({bikes[i].Year}), Has Carrier: {bikes[i].HasCarrier}");
        }
    }
}