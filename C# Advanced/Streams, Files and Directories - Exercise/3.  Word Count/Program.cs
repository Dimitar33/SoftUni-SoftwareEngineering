using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.__Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] words = File.ReadAllLines("../../../words.txt");

            Dictionary<string, int> dict = new Dictionary<string, int>();

            

            for (int i = 0; i < words.Length; i++)
            {
                var match = Regex.Matches(text, $@"\b{words[i].ToLower()}\b");

                foreach (Match item in match)
                {
                    if (!dict.ContainsKey(item.Value))
                    {
                        dict.Add(item.Value, match.Count);
                    }
                   
                }
            }
            string[] result = new string[dict.Count];
            int count = 0;

            foreach (var item in dict)
            {
                result[count] = $"{item.Key} {item.Value}";
                count++;
            }
            File.WriteAllLines("../../../actualResults.txt" ,result);

            count = 0;

            foreach (var item in dict.OrderByDescending(c => c.Value))
            {
                result[count] = $"{item.Key} {item.Value}";
                count++;
            }
            File.WriteAllLines("../../../expectedResult.txt", result);
        }
    }
}
