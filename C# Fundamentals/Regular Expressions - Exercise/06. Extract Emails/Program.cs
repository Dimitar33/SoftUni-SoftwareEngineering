using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(?<=\s)([A-Za-z0-9]+[-._]*)*@[A-Za-z]+([-.]*\w*)*\.[a-z]{2,}";

            var emails = Regex.Matches(input, regex);

            foreach (Match item in emails)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
