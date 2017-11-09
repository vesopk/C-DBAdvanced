using System;
using System.Linq;
using Employee147.Data;

namespace Employee147
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employee147 = db.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name
                        })
                    });

                foreach (var e in employee147)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    foreach (var ep in e.Projects.OrderBy(p => p.Name))
                    {
                        Console.WriteLine($"{ep.Name}");
                    }
                }
            }

        }
    }
}
