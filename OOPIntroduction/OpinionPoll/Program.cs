using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Program
{
    public static void Main()
    {
        var linesCount = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int line = 0; line < linesCount; line++)
        {
            var personInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var name = personInfo[0];
            var age = int.Parse(personInfo[1]);
            var currentPerson = new Person(name,age);
            people.Add(currentPerson);
        }
        foreach (var person in people.Where(p =>p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

