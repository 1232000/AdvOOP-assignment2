using System;
using System.Collections.Generic;
namespace assignment;

public class Program
{
    static void Main(string[] args)
    {
        List<Product> catalog = ProductCatalog.GetProducts();
        ProductService service = new ProductService();

// Task 01: Smart Product Search------------------------------------------------------
        Console.WriteLine("--- Electronics ---");
        List<Product> electronics = service.SearchProducts(
            catalog, p => p.Category == "Electronics");

        service.PrintReport(electronics, p =>
            Console.WriteLine($"{p.Name} - ${p.Price:0.##} (Stock: {p.Stock})"));


        Console.WriteLine("\n--- Under $50 ---");
        List<Product> under50 = service.SearchProducts(
            catalog, p => p.Price < 50);

        service.PrintReport(under50, p =>
            Console.WriteLine($"{p.Name} - ${p.Price:0.##} (Stock: {p.Stock})"));


        Console.WriteLine("\n--- In Stock ---");
        List<Product> inStock = service.SearchProducts(
            catalog, p => p.Stock > 0);

        service.PrintReport(inStock, p =>
            Console.WriteLine($"{p.Name} - ${p.Price:0.##} (Stock: {p.Stock})"));


        Console.WriteLine("\n--- Clothing Under $100 ---");
        List<Product> clothingUnder100 = service.SearchProducts(
            catalog,
            p => p.Category == "Clothing" && p.Price < 100);

        service.PrintReport(clothingUnder100, p =>
            Console.WriteLine($"{p.Name} - ${p.Price:0.##} (Stock: {p.Stock})"));

// Task 03.1: Print Reports------------------------------------------------------
        Console.WriteLine("\n--- Short Report ---");
        service.PrintReport(catalog, p =>
            Console.WriteLine($"{p.Name} - ${p.Price:0.##}"));


        Console.WriteLine("\n--- Detailed Report ---");
        service.PrintReport(catalog, p =>
            Console.WriteLine(
                $"[{p.Category}] {p.Name} | Price: ${p.Price:0.##} | Stock: {p.Stock}"));

// Task 03.2: Transform Products------------------------------------------------------
        Console.WriteLine("\n--- Summary List ---");
        List<string> summary = service.TransformProducts(
            catalog, p => $"{p.Name} (${p.Price:0.##})");

        foreach (string item in summary)
        {
            Console.WriteLine(item);
        }

//Console.WriteLine("\n--- Price Labels ---");
        List<string> priceLabels = service.TransformProducts(
            catalog,
            p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");

        foreach (string label in priceLabels)
        {
            Console.WriteLine(label);
        }

// Task 03.3: Filter Products------------------------------------------------------
        Console.WriteLine("\n--- Low-Stock Alert ---");
        List<Product> lowStock = service.FilterProducts(
            catalog, p => p.Stock < 20);

        service.PrintReport(lowStock, p =>
            Console.WriteLine(
                $"[LOW STOCK] {p.Name}: only {p.Stock} left!"));
    }
}
