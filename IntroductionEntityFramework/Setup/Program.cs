using System;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P02_DatabaseFirst
{
    class Program
    {
        static void Main()
        {
            var dbContex = new SoftUniContext();
            var employees = dbContex.Employees.ToList().OrderBy(e => e.EmployeeId);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
        }
    }
}
