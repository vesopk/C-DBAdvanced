using System;
using System.Linq;
using System.Reflection;


public static class Program
{
    public static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        try
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var box = new Box(length, width, height);
            box.Print();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

