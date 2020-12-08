using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");

            string firstletterRegex = @"([#$&*])([A-Z])+(\1)";
            

            string capitalLetters = string.Join(" ", Regex.Match(input[0], firstletterRegex));

            for (int i = 1; i < capitalLetters.Length - 1; i++)
            {
                char firstLetter = capitalLetters[i];
                int ascii = capitalLetters[i];

                var wordsLenght = Regex.Match(input[1], $@"{ascii}:(?<lenght>[0-9][0-9])");

                int lenght = int.Parse(wordsLenght.Groups["lenght"].Value);

                var thirdPart = Regex.Match(input[2], $@"(?<=\s|^){firstLetter}[^\s]{{{lenght}}}(?=\s|$)");

                Console.WriteLine(thirdPart.Value);

              

            }


        }
    }
}
