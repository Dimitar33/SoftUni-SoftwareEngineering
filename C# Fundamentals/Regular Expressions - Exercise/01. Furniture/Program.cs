using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @">>(?<furniture>[A-Z]*[a-z]*)<<(?<price>\d+\.*\d*)!(?<count>\d+)";

            List<Match> mc = new List<Match>();

            while (input != "Purchase")
            {
                Match order = Regex.Match(input, regex);

                if (order.Success)
                {
                    mc.Add(order);

                }

                input = Console.ReadLine();
            }
            double sum = 0;

            Console.WriteLine("Bought furniture:");
            foreach (var item in mc)
            {
                sum += double.Parse(item.Groups["price"].Value) * double.Parse(item.Groups["count"].Value);
                Console.WriteLine(item.Groups["furniture"]);
            }
            
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
