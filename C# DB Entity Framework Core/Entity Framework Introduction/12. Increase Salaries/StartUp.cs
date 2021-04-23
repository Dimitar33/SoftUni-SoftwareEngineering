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
            Console.WriteLine(IncreaseSalaries(softuni));
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var emp = context.Employees
                .Where(x => departments.Contains(x.Department.Name))             
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var item in emp)
            {
                item.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();


            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");                     

            }
            return sb.ToString().Trim();
        }
    }
}
