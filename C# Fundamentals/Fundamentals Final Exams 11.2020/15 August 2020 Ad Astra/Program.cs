using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _15_August_2020_Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"([#|])(?<food>[A-Za-z ]+)(\1)(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})(\1)(?<calories>[\d]+)(\1)";

            var supplies = Regex.Matches(input, regex);

            int sum = 0;

            foreach (Match item in supplies)
            {
                sum += int.Parse(item.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {sum / 2000} days!");

            foreach (Match item in supplies)
            {
                Console.WriteLine($"Item: {item.Groups["food"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
