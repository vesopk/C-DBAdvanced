using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=.\SQLEXPRESS;Database=Sales;Integrated Security=true";
    }
}
