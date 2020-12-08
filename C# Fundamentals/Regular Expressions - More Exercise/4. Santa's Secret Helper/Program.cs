using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int keyNumber = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            string regex = @"[^-@!:>]*@(?<name>[A-Za-z]+)[^-@!:>]*!(?<behavior>[GN])!";

            while (input != "end")
            {
                string decrypted = string.Join("", input.Select(c => (char)(c - keyNumber)));

                var kid = Regex.Match(decrypted, regex);               

                if (kid.Success)
                {
                    if (kid.Groups["behavior"].Value == "G")
                    {
                        Console.WriteLine(kid.Groups["name"].Value);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
