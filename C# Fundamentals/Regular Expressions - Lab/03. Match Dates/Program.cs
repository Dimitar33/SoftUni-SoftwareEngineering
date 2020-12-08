using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            string regex = @"(?<day>[0-9]{2})([-.\/])(?<month>[A-Z]{1}[a-z]{2})(\1)(?<year>[0-9]{4})";

            var result = Regex.Matches(data, regex);

            foreach (Match item in result)
            {
                Console.WriteLine($"Day: {item.Groups["day"]}, Month: {item.Groups["month"]}, Year: {item.Groups["year"]}");
            }
        }
    }
}
