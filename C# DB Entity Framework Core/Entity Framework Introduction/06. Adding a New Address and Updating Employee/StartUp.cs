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
            Console.WriteLine(AddNewAddressToEmployee(softuni));
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
           
            var adress = new Models.Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4 
            };

            context.Addresses.Add(adress);
            context.SaveChanges();

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.AddressId = adress.AddressId;

            context.SaveChanges();

            var employees = context.Addresses.OrderByDescending(x => x.AddressId).Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.AddressText}");
            }
            return sb.ToString().Trim();
        }
    }
}
