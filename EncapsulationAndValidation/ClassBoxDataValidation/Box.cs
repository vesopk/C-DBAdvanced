using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Height = height;
        this.Width = width;
    }

    private double Length
    {
        get => this.length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    private double Width
    {
        get => this.width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    private double Height
    {
        get => this.height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public double CalculateVolume()
    {
        return Length * Width * Height;
    }

    public double CaculateSurfaceArea()
    {
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    }

    public double CalculateLateralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    public void Print()
    {
        Console.WriteLine($"Surface Area - {CaculateSurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {CalculateVolume():F2}");
    }
}

