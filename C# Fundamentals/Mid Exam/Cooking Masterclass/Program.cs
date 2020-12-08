using System;

namespace Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double flourDiscount = Math.Floor(students / 5);
            double extraAprons = Math.Ceiling(students * 0.2);

            double flour = (students - flourDiscount) * flourPrice;
            double eggs = students * eggPrice * 10;
            double aprons = (students + extraAprons )* apronPrice ;

            double total = flour + eggs + aprons;

            if (budget >= total)
            {
                Console.WriteLine($"Items purchased for {total:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(total - budget):F2}$ more needed.");
            }
        }
    }
}
