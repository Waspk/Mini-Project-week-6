// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using ProductListApp;

List<Product> productList = new List<Product>();

while (true)
{
    Console.WriteLine("Enter category (or 'q' to quit): ");
    string category = Console.ReadLine();
    if (category.ToLower() == "q") break;

    Console.WriteLine("Enter product name: ");
    string productName = Console.ReadLine();
    if (productName.ToLower() == "q") break;

    Console.WriteLine("Enter price: ");
    double price;
    while (!double.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Invalid price. Please enter a valid price:");
    }

    productList.Add(new Product(category, productName, price));
}

Console.WriteLine("\nProduct List:");
productList = productList.OrderBy(p => p.Price).ToList(); // Sort by price

foreach (var product in productList)
{
    Console.WriteLine($"{product.Name} ({product.Category}): ${product.Price}");
}

double totalPrice = productList.Sum(p => p.Price);
Console.WriteLine($"Total Price: ${totalPrice}");

namespace ProductListApp
{
    // Class representing a product
    class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string category, string name, double price)
        {
            Category = category;
            Name = name;
            Price = price;
        }
    }
}

