using System;
using System.Collections.Generic;
using System.Linq;
using Product_Management_System;

class Program
{

    static List<Product> products = new List<Product>
{
new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1000, Stock = 5 },
new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 700, Stock = 0 },
new Product { Id = 3, Name = "Shirt", Category = "Clothing", Price = 50, Stock = 10 },
new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 80, Stock = 3 },
new Product { Id = 5, Name = "TV", Category = "Electronics", Price = 1500, Stock = 2 },
new Product { Id = 6, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 0 }
};

static void AddProduct()
    {
        try
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be empty.");

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(category))
                throw new Exception("Category cannot be empty.");

            Console.Write("Enter Price: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
                throw new Exception("Invalid price.");

            Console.Write("Enter Stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                throw new Exception("Invalid stock value.");

            int newId = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;

            products.Add(new Product
            {
                Id = newId,
                Name = name,
                Category = category,
                Price = price,
                Stock = stock
            });

            Console.WriteLine("Product added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ShowAvailableProducts()
    {
        var available = products.Where(p => p.Stock > 0);

        if (!available.Any())
        {
            Console.WriteLine("No available products.");
            return;
        }

        Console.WriteLine("\nAvailable Products:");
        foreach (var p in available)
            Console.WriteLine($"{p.Id}. {p.Name} | Stock: {p.Stock}");
    }

    static void ShowAveragePrice()
    {
        if (!products.Any())
        {
            Console.WriteLine("No products available.");
            return;
        }

        var avg = products
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                AvgPrice = g.Average(p => p.Price)
            });

        Console.WriteLine("\nAverage Price:");
        foreach (var item in avg)
            Console.WriteLine($"{item.Category}: {item.AvgPrice}");
    }

    static void ShowTop3()
    {
        var top3 = products
            .OrderByDescending(p => p.Price)
            .Take(3);

        if (!top3.Any())
        {
            Console.WriteLine("No products available.");
            return;
        }

        Console.WriteLine("\nTop 3 Expensive Products:");
        foreach (var p in top3)
            Console.WriteLine($"{p.Name} - {p.Price}");
    }

    static void GroupByCategory()
    {
        if (!products.Any())
        {
            Console.WriteLine("No products available.");
            return;
        }

        var grouped = products.GroupBy(p => p.Category);

        Console.WriteLine("\nGrouped Products:");
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key + ":");
            foreach (var p in group)
                Console.WriteLine(" - " + p.Name);
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n==== PRODUCT MENU ====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Available Products (Stock > 0)");
            Console.WriteLine("3. Average Price per Category");
            Console.WriteLine("4. Top 3 Expensive Products");
            Console.WriteLine("5. Group by Category");
            Console.WriteLine("6. Exit");

            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ShowAvailableProducts();
                    break;
                case "3":
                    ShowAveragePrice();
                    break;
                case "4":
                    ShowTop3();
                    break;
                case "5":
                    GroupByCategory();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
