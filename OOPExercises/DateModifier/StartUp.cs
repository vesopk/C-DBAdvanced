using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class StartUp
{
    public static void Main()
    {
        var dateOne = Console.ReadLine();
        var dateTwo = Console.ReadLine();
        var dateModifier = new DateModifier();
        Console.WriteLine(dateModifier.CalculateDaysDiff(dateOne, dateTwo));
        ;
    }
}
