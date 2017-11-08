using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public string Model { get; private set; }
    public Engine Engine { get; private set; }
    public Cargo Cargo { get; private set; }
    public IReadOnlyCollection<Tire> Tires => tires;

    public Car(string model, Engine engine, Cargo cargo)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        this.tires = new List<Tire>();
    }

    public void AddTire(Tire tire)
    {
        tires.Add(tire);
    }
}
