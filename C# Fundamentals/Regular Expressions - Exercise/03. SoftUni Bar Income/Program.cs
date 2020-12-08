using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0;

            while (input != "end of shift")
            {
                string regex = @"^%(?<name>[A-Z][a-z]+)%[^|\.%$]*<(?<product>\w+)>[^|\.%$]*\|(?<count>\d+)\|[^|\%$0-9]*(?<price>\d+\.*\d*)\$";

                var result = Regex.Match(input, regex);

                if (result.Success)
                {
                    total += double.Parse(result.Groups["count"].Value) * double.Parse(result.Groups["price"].Value);

                    Console.WriteLine($"{result.Groups["name"]}: {result.Groups["product"]} - {(double.Parse(result.Groups["count"].Value) * double.Parse(result.Groups["price"].Value)):f2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
