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
            Console.WriteLine(GetAddressesByTown(softuni));
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {

            var employees = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Employees,
                    TownName = x.Town.Name
                })
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10).ToList();
               

            StringBuilder sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.AddressText}, {item.TownName} - {item.Employees.Count} employees");
       
            }
            return sb.ToString().Trim();
        }
    }
}
