
public class Tire
{
    private double tirePressure;
    private double tireAge;

    public double TirePressure { get; private set; }
    public double TireAge { get; private set; }

    public Tire(double tirePressure, double tireAge)
    {
        TirePressure = tirePressure;
        TireAge = tireAge;
    }
}
