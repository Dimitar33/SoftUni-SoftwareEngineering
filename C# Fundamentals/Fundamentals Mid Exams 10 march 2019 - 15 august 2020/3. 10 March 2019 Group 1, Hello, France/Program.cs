using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._10_March_2019_Group_1__Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] store = Console.ReadLine().Split(new string[] { "->", "|" }, StringSplitOptions.RemoveEmptyEntries);

            double budget = double.Parse(Console.ReadLine());
            List<double> bought = new List<double>();
            double profit = 0;


            for (int i = 0; i < store.Length; i += 2)
            {
                double prise = double.Parse(store[i + 1]);
                string stock = store[i];

                if (stock == "Clothes" && prise <= 50 && budget >= prise)
                {
                    bought.Add(prise + prise * 0.4);
                    budget -= prise;
                    profit += prise * 0.4;
                }
                else if (stock == "Shoes" && prise <= 35 && budget >= prise)
                {
                    bought.Add(prise + prise * 0.4);
                    budget -= prise;
                    profit += prise * 0.4;
                }
                else if (stock == "Accessories" && prise <= 20.5 && budget >= prise)
                {
                    bought.Add(prise + prise * 0.4);
                    budget -= prise;
                    profit += prise * 0.4;
                }
            }

            foreach (var item in bought)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");

            if (bought.Sum() + budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
