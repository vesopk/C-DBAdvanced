using System;
using System.Linq;
using EmployeesFromResearchAndDevelopment.Data;

namespace EmployeesFromResearchAndDevelopment
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        DepartemtName = e.Department.Name,
                        e.Salary
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name} from {e.DepartemtName} - ${e.Salary:F2}");
                }
            }

        }
    }
}
