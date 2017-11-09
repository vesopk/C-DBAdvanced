using System;
using System.Linq;
using AddingANewTownAndUpdateEmployee.Data.Models;

namespace AddingANewTownAndUpdateEmployee
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {

                var adress = new Address()
                {
                    TownId = 4,
                    AddressText = "Vitoshka 15"
                };
                db.Addresses.Add(adress);
                var nakov = db.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
                nakov.Address = adress;

                db.SaveChanges();

                var result = db.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText);

                foreach (var a in result)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
}
