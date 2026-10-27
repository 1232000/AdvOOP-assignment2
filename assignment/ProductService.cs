using assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace assignment;

public class ProductService
{
    // Func returns true or false to filter products.
    public List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }

    // Action performs an operation without returning a value.
    public void PrintReport(
        List<Product> products,
        Action<Product> printAction)
    {
        foreach (Product product in products)
        {
            printAction(product);
        }
    }

    // Func transforms each product into a string.
    public List<string> TransformProducts(
        List<Product> products,
        Func<Product, string> transform)
    {
        List<string> result = new List<string>();

        foreach (Product product in products)
        {
            result.Add(transform(product));
        }

        return result;
    }

    // Predicate checks whether a product matches a condition.
    public List<Product> FilterProducts(
        List<Product> products,
        Predicate<Product> condition)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (condition(product))
            {
                result.Add(product);
            }
        }

        return result;
    }
}