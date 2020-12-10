using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09_August_2020_Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"([=\/])(?<town>[A-Z][A-Za-z]{2,})(\1)";
            int travelPoints = 0;
            List<string> towns = new List<string>();

            var locations = Regex.Matches(input, regex);

            foreach (Match item in locations)
            {
                travelPoints += item.Groups["town"].Length;
                towns.Add(item.Groups["town"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", towns)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
