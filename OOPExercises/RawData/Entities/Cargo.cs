public class Cargo
{
    private double cargoWeight;
    private string cargoType;

    public double CargoWeight { get; private set; }
    public string CargoType { get; private set; }

    public Cargo(double cargoWeight, string cargoType)
    {
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }
}
