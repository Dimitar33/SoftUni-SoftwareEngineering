using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string regex = @"([^0-9]+)([0-9]+)";

            var matches = Regex.Matches(input, regex);

            StringBuilder sb = new StringBuilder();
            StringBuilder allChars = new StringBuilder();


            foreach (Match item in matches)
            {

                if (item.Groups[2].Value != "0")
                {
                    allChars.Append(item.Groups[1].Value);

                }

                for (int i = 0; i < int.Parse(item.Groups[2].Value); i++)
                {
                    sb.Append(item.Groups[1].Value);
                }

            }

            var count = allChars.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(sb.ToString());
        }
    }
}
