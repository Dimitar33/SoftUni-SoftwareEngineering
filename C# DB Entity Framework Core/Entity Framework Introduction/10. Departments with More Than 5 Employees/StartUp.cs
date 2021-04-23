using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softuni = new SoftUniContext();
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(softuni));
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

            var employees = context.Departments
               
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    emplyee = x.Employees.Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle                        
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var item in employees)
            {
                sb.AppendLine($"{item.Name} - {item.ManagerFirstName} {item.ManagerLastName}");

                foreach (var emp in item.emplyee)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

            }
            return sb.ToString().Trim();
        }
    }
}
