using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class Program
{
    public static void Main()
    {
        var peopleInfo = Console.ReadLine().Split(';').ToArray();
        var productInfo = Console.ReadLine().Split(';').ToArray();

        var people = new List<Person>();
        var products = new List<Product>();

        try
        {
            for (int i = 0; i < peopleInfo.Length; i++)
            {
                var currentPersonInfo = peopleInfo[i].Split('=').ToArray();
                var name = currentPersonInfo[0];
                var money = decimal.Parse(currentPersonInfo[1]);

                var currentPerson = new Person(name,money);
                people.Add(currentPerson);
            }

            for (int i = 0; i < productInfo.Length; i++)
            {
                var currentProductInfo = productInfo[i].Split('=').ToArray();
                var name = currentProductInfo[0];
                var price = decimal.Parse(currentProductInfo[1]);

                var currentProduct = new Product(name,price);
                products.Add(currentProduct);
            }

            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                var inputParams = input.Split(' ').ToArray();
                var personName = inputParams[0];
                var productName = inputParams[1];

                foreach (var person in people.Where(p => p.Name.Equals(personName)))
                {
                    foreach (var product in products.Where(p => p.Name.Equals(productName)))
                    {
                        person.BuyProduct(product);
                    }
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Any())
                {
                    var sb = new StringBuilder();
                    foreach (var personProduct in person.Products)
                    {
                        sb.Append(personProduct.Name);
                        sb.Append(", ");
                    }
                    Console.WriteLine($"{person.Name} - {sb.ToString().Trim().TrimEnd(',')}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}

