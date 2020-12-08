using System;
using System.Text;

namespace _12_August_2020_Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string special = Console.ReadLine();
            double tax = 0;
            double noTax = 0;

            while (special != "special" && special != "regular")
            {

                double price = double.Parse(special);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    special = Console.ReadLine();
                    continue;
                }
                noTax += price;
                tax += price * 0.2;
                special = Console.ReadLine();

            }
            double total = noTax + tax;
            if (special == "special")
            {
                total *= 0.9;

            }
            if (noTax == 0)
            {
                Console.WriteLine("Invalid order!");
                Environment.Exit(0);
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {noTax:f2}$");
            Console.WriteLine($"Taxes: {tax:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}
