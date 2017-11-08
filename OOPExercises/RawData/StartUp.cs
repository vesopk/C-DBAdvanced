using System;
using System.Collections.Generic;
using System.Linq;


public static class StartUp
{
    public static void Main()
    {
        var linesCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        for (int index = 0; index < linesCount; index++)
        {
            var carInfo = Console.ReadLine().Split();
            var model = carInfo[0];

            var engineSpeed = double.Parse(carInfo[1]);
            var enginePower = double.Parse(carInfo[2]);

            var cargoWeight = double.Parse(carInfo[3]);
            var cargoType = carInfo[4];

            var tireOnePressure = double.Parse(carInfo[5]);
            var tireOneAge = double.Parse(carInfo[6]);

            var tireTwoPressure = double.Parse(carInfo[7]);
            var tireTwoAge = double.Parse(carInfo[8]);

            var tireThreePressure = double.Parse(carInfo[9]);
            var tireThreeAge = double.Parse(carInfo[10]);

            var tireFourPressure = double.Parse(carInfo[11]);
            var tireFourAge = double.Parse(carInfo[12]);

            var engine = new Engine(engineSpeed,enginePower);

            var cargo = new Cargo(cargoWeight,cargoType);

            var tireOne = new Tire(tireOnePressure,tireOneAge);
            var tireTwo = new Tire(tireTwoPressure,tireTwoAge);
            var tireThree = new Tire(tireThreePressure,tireThreeAge);
            var tireFour = new Tire(tireFourPressure,tireFourAge);

            var car = new Car(model,engine,cargo);
            car.AddTire(tireOne);
            car.AddTire(tireTwo);
            car.AddTire(tireThree);
            car.AddTire(tireFour);

            cars.Add(car);
        }

        var type = Console.ReadLine();

        if (type == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == type && c.Tires.Any(t => t.TirePressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (type == "flammable")
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == type && c.Engine.EnginePower > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
