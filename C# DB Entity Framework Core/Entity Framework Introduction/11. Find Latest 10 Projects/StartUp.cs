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
            Console.WriteLine(GetLatestProjects(softuni));
        }
        public static string GetLatestProjects(SoftUniContext context)
        {

            var proj = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderBy(x => x.Name).ToList();
               

            StringBuilder sb = new StringBuilder();


            foreach (var item in proj)
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"{item.Description}");
                sb.AppendLine($"{item.StartDate}");
            

            }
            return sb.ToString().Trim();
        }
    }
}
