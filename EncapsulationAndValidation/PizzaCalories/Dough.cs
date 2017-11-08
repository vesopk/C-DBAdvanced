using System;

public class Dough
{
    private const double whiteModifier = 1.5;
    private const double wholegrainModifier = 1.0;
    private const double crispyModifier = 0.9;
    private const double chewyModifier = 1.1;
    private const double homemadeModifier = 1.0;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    private string FlourType
    {
        get => this.flourType;
        set
        {
            if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
            {
                this.flourType = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }

    private string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            if (value.ToLower() == "chewy" || value.ToLower() == "crispy" || value.ToLower() == "homemade")
            {
                this.bakingTechnique = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value < 1 && value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double DoughCaloriesCalculate()
    {
        var calories = weight * 2;
        if (bakingTechnique.ToLower() == "chewy")
        {
            calories *= chewyModifier;
        }
        else if (bakingTechnique.ToLower() == "crispy")
        {
            calories *= crispyModifier;
        }
        else if (bakingTechnique.ToLower() == "homemade")
        {
            calories *= homemadeModifier;
        }

        if (flourType.ToLower() == "white")
        {
            calories *= whiteModifier;
        }
        else if (flourType.ToLower() == "wholegrain")
        {
            calories *= wholegrainModifier;
        }

        return calories;
    }
}

