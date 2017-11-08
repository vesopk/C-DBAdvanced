using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPer1Km { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPer1Km)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPer1Km = fuelConsumptionPer1Km;
        DistanceTraveled = 0;
    }

    public void Drive(double distance)
    {
        var requiredFuel = distance * this.FuelConsumptionPer1Km;

        if (FuelAmount >= requiredFuel)
        {
            FuelAmount -= requiredFuel;
            DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
    
}

