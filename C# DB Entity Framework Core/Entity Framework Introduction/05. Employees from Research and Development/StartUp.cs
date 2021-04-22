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
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softuni));
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => 
                x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from {item.DepartmentName} - ${item.Salary:f2}");
            }
            return sb.ToString().Trim();
        }
    }
}
