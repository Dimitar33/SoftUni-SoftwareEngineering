using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> chars = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (chars.ContainsKey(text[i]))
                {
                    chars[text[i]]++;
                }
                else
                {
                    chars.Add(text[i], 1);
                }
            }
            chars = chars.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
