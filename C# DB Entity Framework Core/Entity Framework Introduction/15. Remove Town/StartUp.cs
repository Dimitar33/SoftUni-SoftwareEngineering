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
            Console.WriteLine(RemoveTown(softuni));
        }
        public static string RemoveTown(SoftUniContext context)
        {

            var town = context.Towns.First(x => x.Name == "Seattle");

            var adreses = context.Addresses.Where(x => x.TownId == town.TownId);
            int count = adreses.Count();

            var emp = context.Employees
                .Where(x => adreses.Any(c => c.AddressId == x.AddressId));

            foreach (var item in emp)
            {
                item.AddressId = null;
            }
            foreach (var item in adreses)
            {
                context.Addresses.Remove(item);
            }

            context.Towns.Remove(town);

            context.SaveChanges(); 

            return $"{count} addresses in {town.Name} were deleted";
        }
    }
}
