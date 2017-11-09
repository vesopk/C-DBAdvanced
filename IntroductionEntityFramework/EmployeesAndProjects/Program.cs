using System;
using System.Globalization;
using System.Linq;
using EmployeesAndProjects.Data;

namespace EmployeesAndProjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(
                        e => e.EmployeesProjects.Any(ep =>
                            ep.Project.StartDate.Year >= 2001 &&
                            ep.Project.StartDate.Year <= 2003
                        ))
                    .Take(30)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name} - Manager: {e.ManagerName}");
                    foreach (var p in e.Projects)
                    {
                        Console.Write($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)} - ");
                        if (p.EndDate == null)
                        {
                            Console.WriteLine("not finished");
                        }
                        else
                        {
                            Console.WriteLine($"{p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
            }
        }
    }
}
