using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Program
{
   public static void Main()
   {
       var linesCount = int.Parse(Console.ReadLine());
       var departmentTopSalary = new Dictionary<string, List<decimal>>();
       var employees = new List<Employee>();

       for (int i = 0; i < linesCount; i++)
       {
           var employeeInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
           int tempAge;

           if (employeeInfo.Length == 6)
           {
               var name = employeeInfo[0];
               var salary = decimal.Parse(employeeInfo[1]);
               var position = employeeInfo[2];
               var department = employeeInfo[3];
               var email = employeeInfo[4];
               var age = int.Parse(employeeInfo[5]);

               var currentEmployee = new Employee(name,salary,position,department,email,age);
               if (!departmentTopSalary.ContainsKey(department))
               {
                   departmentTopSalary[department] = new List<decimal>();
               }
               departmentTopSalary[department].Add(salary);
               employees.Add(currentEmployee);
           }

           else if (employeeInfo.Length == 5 && int.TryParse(employeeInfo[4],out tempAge))
           {
               var name = employeeInfo[0];
               var salary = decimal.Parse(employeeInfo[1]);
               var position = employeeInfo[2];
               var department = employeeInfo[3];
               var age = int.Parse(employeeInfo[4]);

               var currentEmployee = new Employee(name, salary, position, department,age);
               if (!departmentTopSalary.ContainsKey(department))
               {
                   departmentTopSalary[department] = new List<decimal>();
               }
               departmentTopSalary[department].Add(salary);
               employees.Add(currentEmployee);
            }
           else if(employeeInfo.Length == 5)
           {
               var name = employeeInfo[0];
               var salary = decimal.Parse(employeeInfo[1]);
               var position = employeeInfo[2];
               var department = employeeInfo[3];
               var email = employeeInfo[4];

               var currentEmployee = new Employee(name, salary, position, department, email);
               if (!departmentTopSalary.ContainsKey(department))
               {
                   departmentTopSalary[department] = new List<decimal>();
               }
               departmentTopSalary[department].Add(salary);
               employees.Add(currentEmployee);
            }
           else
           {
               var name = employeeInfo[0];
               var salary = decimal.Parse(employeeInfo[1]);
               var position = employeeInfo[2];
               var department = employeeInfo[3];

               var currentEmployee = new Employee(name, salary, position, department);
               if (!departmentTopSalary.ContainsKey(department))
               {
                   departmentTopSalary[department] = new List<decimal>();
               }
               departmentTopSalary[department].Add(salary);
               employees.Add(currentEmployee);
            }
       }
       var topDepartment = departmentTopSalary.OrderByDescending(d => d.Value.Average()).Take(1);
       foreach (var keyValuePair in topDepartment)
       {
           Console.WriteLine($"Highest Average Salary: {keyValuePair.Key}");
           foreach (var employee in employees.Where(e => e.Department == keyValuePair.Key).OrderByDescending(e => e.Salary))
           {
               Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
           }
       }
   }
}

