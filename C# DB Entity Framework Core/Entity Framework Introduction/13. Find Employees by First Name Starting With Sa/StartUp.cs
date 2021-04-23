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
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(softuni));
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var emp = context.Employees
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                //.Where(x => x.FirstName.StartsWith("Sa")) (also valid)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName).ToList();
                

            StringBuilder sb = new StringBuilder();


            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");                     

            }
            return sb.ToString().Trim();
        }
    }
}
