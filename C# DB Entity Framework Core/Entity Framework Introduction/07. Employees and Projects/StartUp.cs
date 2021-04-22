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
            Console.WriteLine(GetEmployeesInPeriod(softuni));
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(x => new
                    {
                        x.Project.Name,
                        x.Project.StartDate,
                        x.Project.EndDate
                    })
                })
                .Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - Manager: {item.ManagerFirstName} {item.ManagerLastName}");

                foreach (var project in item.Projects)
                {
                    string endDate = project.EndDate.HasValue ? project.EndDate.Value
                        .ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
