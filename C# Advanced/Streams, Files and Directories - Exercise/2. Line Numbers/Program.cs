using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            string regex = @"[-,.!?']";
            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var matches = Regex.Matches(lines[i], regex);
                int count = 0;

                foreach (var item in lines[i])
                {
                    if (char.IsLetter(item))
                    {
                        count++;
                    }
                }
                result[i] = $"Line {i + 1}: {lines[i]} ({count})({matches.Count})";
                
            }
            File.WriteAllLines("../../../result.txt", result);
        }
    }
}
