using System;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
