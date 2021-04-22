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
            Console.WriteLine(GetEmployee147(softuni));
        }
        public static string GetEmployee147(SoftUniContext context)
        {

            var employee = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    projects = x.EmployeesProjects.Select(x => new
                    {
                        x.Project.Name
                    })
                })
        
                .FirstOrDefault(x => x.EmployeeId == 147);
               
               

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var item in employee.projects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{item.Name}");
       
            }
            return sb.ToString().Trim();
        }
    }
}
