using System;
using System.Reflection;


public static class Program
{
    public static void Main()
    {
        Type personType = typeof(Person);
        PropertyInfo[] properties = personType.GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(properties.Length);

        var firstPerson = new Person() {Age = 20, Name = "Pesho"};
        var secondPerson = new Person() {Age = 18, Name = "Gosho"};
        var thirdPerson = new Person() {Age = 43, Name = "Stamat"};
    }
}
