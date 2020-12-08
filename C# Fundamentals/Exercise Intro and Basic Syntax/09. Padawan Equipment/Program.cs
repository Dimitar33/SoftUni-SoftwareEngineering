using System;
using System.Runtime.InteropServices.ComTypes;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double sabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double saberCount = Math.Ceiling(students * 1.1);
            int beltCount = students - (students / 6);

            double total = saberCount * sabrePrice + students * robePrice + beltCount * beltPrice;
            double diff = Math.Abs(total - budget);

            if (budget >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {diff:f2}lv more.");
            }
        }
    }
}
