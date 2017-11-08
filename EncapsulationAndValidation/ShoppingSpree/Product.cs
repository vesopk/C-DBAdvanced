using System;

public class Product
{
    private string name;
    private decimal price;

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

    public decimal Price
    {
        get => this.price;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Price cannot be zero or negative");
            }
            this.price = value;
        }
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
