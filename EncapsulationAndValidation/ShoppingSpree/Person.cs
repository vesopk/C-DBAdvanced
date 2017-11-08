using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }
    public decimal Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> Products => products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }


    public void BuyProduct(Product product)
    {
        if (money >= product.Price)
        {
            money -= product.Price;
            products.Add(product);
            Console.WriteLine($"{name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{name} can't afford {product.Name}");
        }
    }
}

