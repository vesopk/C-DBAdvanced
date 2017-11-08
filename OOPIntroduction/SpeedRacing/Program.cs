using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Program
{
    public static void Main()
    {
        var carsCount = int.Parse(Console.ReadLine());
        var cars = new Dictionary<string, Car>();

        for (int i = 0; i < carsCount; i++)
        {
            var carInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var carModel = carInfo[0];
            var fuelAmount = double.Parse(carInfo[1]);
            var fuelConsumptionPer1Km = double.Parse(carInfo[2]);

            var currentCar = new Car(carModel,fuelAmount,fuelConsumptionPer1Km);
            cars.Add(carModel,currentCar);
        }

        string input;

        while (!(input = Console.ReadLine()).Equals("End"))
        {
            var carToDrive = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var model = carToDrive[1];
            var distance = double.Parse(carToDrive[2]);

            cars[model].Drive(distance);
        }

        foreach (var car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
        }
    }
}

