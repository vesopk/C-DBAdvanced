using System;
using System.Linq;
using EmployeesWithSalaryAbove50000.Data;

namespace EmployeesWithSalaryAbove50000
{
    class Program
    {
        static void Main()
        {
            var contex = new SoftUniContext();
            var employees = contex.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
