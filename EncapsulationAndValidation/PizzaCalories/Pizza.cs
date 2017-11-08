using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get => this.name;
        private set
        {
            if ((value.Length < 1 && value.Length > 15) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.dough = null;
        this.toppings = new List<Topping>();
    }

    public void SetDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count < 11)
        {
            toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    public double CalculateTotalCalories()
    {
        var calories = dough.DoughCaloriesCalculate();
        foreach (var topping in toppings)
        {
            calories += topping.ToppingCaloriesCalculate();
        }
        return calories;
    }
}

