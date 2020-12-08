using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().Replace(" ", "");

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if ( dict.ContainsKey(text[i]))
                {
                    dict[text[i]]++;
                }
                else
                {
                    dict.Add(text[i], 1);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
