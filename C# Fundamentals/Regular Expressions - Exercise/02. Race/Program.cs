using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();

            string text = Console.ReadLine();

            Dictionary<string, int> runners = new Dictionary<string, int>();

            while (text != "end of race")
            {
                string lettersPattrn = "[A-Za-z]";
                string digitsPattern = "\\d";

                var letters = Regex.Matches(text, lettersPattrn);
                var digits = Regex.Matches(text, digitsPattern);

                string name = string.Join("", letters);
                

                int[] nums = digits.Select(c => int.Parse(c.Value)).ToArray();
                int distance = nums.Sum();


                if (names.Contains(name))
                {
                    if (runners.ContainsKey(name))
                    {
                        runners[name] += distance;
                            
                    }
                    else
                    {
                        runners.Add(name, distance);
                    }
                }
                text = Console.ReadLine();
            }

            string[] winers = runners.OrderByDescending(c => c.Value).Select(c =>c.Key).ToArray();

            Console.WriteLine($"1st place: {winers[0]}");
            Console.WriteLine($"2nd place: {winers[1]}");
            Console.WriteLine($"3rd place: {winers[2]}");
        }
    }
}
