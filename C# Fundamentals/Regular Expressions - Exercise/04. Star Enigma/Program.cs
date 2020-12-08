using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string regex = @"(?i)[star]";
            string regex2 = @"@(?<name>[A-Za-z]+)[^-@!:>]*:(?<pop>\d+)[^-@!:>]*!(?<type>[AD])![^-@!:>]*->(?<soldiers>\d+)";

            List<string> planetsAttack = new List<string>();
            List<string> planetsDefence = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string messege = Console.ReadLine();
                int key = Regex.Matches(messege, regex).Count;

                var decryptedList = messege.Select(c => (char)(c - key));
                string decrypted = string.Join("", decryptedList);
                var match = Regex.Match(decrypted, regex2);

                if (match.Success)
                {
                    if (match.Groups["type"].Value == "A")
                    {
                        planetsAttack.Add(match.Groups["name"].Value);
                    }
                    else
                    {
                        planetsDefence.Add(match.Groups["name"].Value);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {planetsAttack.Count}");

            foreach (var item in planetsAttack.OrderBy(c => c))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {planetsDefence.Count}");

            foreach (var item in planetsDefence.OrderBy(c => c))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
