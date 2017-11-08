using System;
using System.Linq;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public string Author
    {
        get => author;
        private set
        {
            var authorNames = value.Split().ToArray();
            if (char.IsDigit(authorNames[1].First()))
            {
                throw new ArgumentException("Author not valid!");
            }
            else
            {
                author = value;
            }
        }
    }

    public string Title
    {
        get => title;
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            else
            {
                title = value;
            }
        }
    }

    public virtual decimal Price
    {
        get => price;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").Append(this.GetType().Name)
            .Append(Environment.NewLine)
            .Append("Title: ").Append(this.Title)
            .Append(Environment.NewLine)
            .Append("Author: ").Append(this.Author)
            .Append(Environment.NewLine)
            .Append(String.Format("Price: {0:F1}", this.Price))
            .Append(Environment.NewLine);

        return sb.ToString();
    }

}

