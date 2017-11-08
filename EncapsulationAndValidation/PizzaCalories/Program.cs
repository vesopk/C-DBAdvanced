using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Program
{
    public static void Main()
    {
        try
        {
            var pizzaInfo = Console.ReadLine().Split().ToArray();
            var pizzaName = pizzaInfo[1];
            var pizza = new Pizza(pizzaName);

            var doughInfo = Console.ReadLine().Split().ToArray();
            var flourType = doughInfo[1];
            var bakingTechnique = doughInfo[2];
            var doughWeight = double.Parse(doughInfo[3]);

            var dough = new Dough(flourType, bakingTechnique, doughWeight);
            pizza.SetDough(dough);

            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                var inputParams = input.Split().ToArray();

                var toppingType = inputParams[1];
                var weight = double.Parse(inputParams[2]);

                var topping = new Topping(toppingType, weight);

                pizza.AddTopping(topping);
            }
            Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():F2} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

