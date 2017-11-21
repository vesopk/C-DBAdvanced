using System;
using P03_SalesDatabase.Data;

namespace SalesStartup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
