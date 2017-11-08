using System;


public class Topping
{
    private const double meatModifier = 1.2;
    private const double veggies = 0.8;
    private const double cheese = 1.1;
    private const double sauce = 0.9;

    private string toppingType;
    private double weight;

    private string ToppingType
    {
        get => this.toppingType;
        set
        {
            if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "sauce" || value.ToLower() == "cheese")
            {
                this.toppingType = value;
            }
            else
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value > 0 && value < 51)
            {
                this.weight = value;
            }
            else
            {
                throw new ArgumentException($"{toppingType} weight should be in the range[1..50].");
            }
        }
    }

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public double ToppingCaloriesCalculate()
    {
        var calories = weight * 2;
        if (toppingType.ToLower() == "meat")
        {
            calories *= meatModifier;
        }
        else if (toppingType.ToLower() == "veggies")
        {
            calories *= veggies;
        }
        else if (toppingType.ToLower() == "cheese")
        {
            calories *= cheese;
        }
        else if (toppingType.ToLower() == "sauce")
        {
            calories *= sauce;
        }
        return calories;
    }

}

