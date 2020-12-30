using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (StreamReader readerText = new StreamReader("../../../text.txt"))
            {

                StreamReader readerWords = new StreamReader("../../../words.txt");

                string[] words = readerWords.ReadToEnd().ToLower().Split().ToArray();
                string text = readerText.ReadToEnd().ToLower();

                for (int i = 0; i < words.Length; i++)
                {
                                 
                    var match = Regex.Matches(text, @$"\b{words[i]}\b");
                    dict.Add(words[i], match.Count);
                }

            }
            foreach (var item in dict.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var item in dict.OrderByDescending(c => c.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
