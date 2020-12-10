using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04_April_2020_Group_1_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string emogiesRegex = @"([:]{2}|[*]{2})(?<emote>[A-Z][a-z]{2,})(\1)";

            var emogies = Regex.Matches(text, emogiesRegex);           
            var nums = Regex.Matches(text, @"\d");
            int coolTreshold = 1;
           
            StringBuilder sb = new StringBuilder();

            foreach (Match item in nums)
            {
               coolTreshold *= int.Parse(item.Value);
            }
            foreach (Match item in emogies)
            {
                int coolnes = 0;

                for (int i = 0; i < item.Groups["emote"].Value.Length; i++)
                {
                    coolnes += item.Groups["emote"].Value[i];
                }
                if (coolnes > coolTreshold)
                {
                    sb.AppendLine(item.Value);
                }
            }
            if (sb != null)
            {
                Console.WriteLine($"Cool threshold: {coolTreshold}");
                Console.WriteLine($"{emogies.Count} emojis found in the text. The cool ones are:");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
