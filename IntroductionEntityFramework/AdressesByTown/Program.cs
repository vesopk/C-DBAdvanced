using System;
using System.Linq;
using AdressesByTown.Data;

namespace AdressesByTown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var adresses = db.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        a.AddressText,
                        TownName = $"{a.Town.Name}",
                        EmployeeCount = $"{a.Employees.Count}"
                    });

                foreach (var a in adresses)
                {
                    Console.WriteLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount}");
                }
            }
        }
    }
}
