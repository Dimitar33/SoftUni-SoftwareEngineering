using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _10_April_2020_Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string regex = @"([@#])(?<word>[A-Za-z]{3,})(\1)(\1)(?<word2>[A-Za-z]{3,})(\1)";

            List<string> words = new List<string>();

            StringBuilder sb = new StringBuilder();

            var pairs = Regex.Matches(text, regex);

            for (int i = 0; i < pairs.Count; i++)
            {
                char[] temp = (pairs[i].Groups["word2"].Value).ToCharArray();
                Array.Reverse(temp);
                string reverse = new string(temp);

                if (pairs[i].Groups["word"].Value == reverse)
                {                   
                    words.Add(pairs[i].Groups["word"].Value + " <=> " + pairs[i].Groups["word2"].Value);
                }
            }
            if (pairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{pairs.Count } word pairs found!");
                if (words.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");                    
                    Console.WriteLine(string.Join(", " , words));
                }
            }
        }
    }
}
