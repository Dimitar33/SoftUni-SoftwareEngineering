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
            Console.WriteLine(DeleteProjectById(softuni));
        }
        public static string DeleteProjectById(SoftUniContext context)
        {

            var proj = context.Projects.Find(2);

            var emp = context.EmployeesProjects
                .Where(x => x.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(emp);

            context.Projects.Remove(proj);

            context.SaveChanges();

            var projects = context.Projects.Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in projects)
            {
                sb.AppendLine($"{item.Name}");

            }
            return sb.ToString().Trim();
        }
    }
}
