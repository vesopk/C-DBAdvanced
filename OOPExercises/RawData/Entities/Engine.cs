
public class Engine
{
    private double engineSpeed;
    private double enginePower;

    public double EngineSpeed { get; private set; }
    public double EnginePower { get; private set; }

    public Engine(double engineSpeed, double enginePower)
    {
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
    }
}
