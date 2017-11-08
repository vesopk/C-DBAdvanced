using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public static class Program
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        var linesCount = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < linesCount; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);
            var person = new Person(name,age);
            family.AddMember(person);
        }
        var oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

