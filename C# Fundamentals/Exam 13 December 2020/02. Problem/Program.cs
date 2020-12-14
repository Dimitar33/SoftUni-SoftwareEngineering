using System;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inpit = Console.ReadLine();

                string regex = @"(.+)>(?<nums>[\d]{3})\|(?<smal>[a-z]{3})\|(?<big>[A-Z]{3})\|(?<simb>[^><]{3})<(\1)";

                var validPass = Regex.Match(inpit, regex);
                string pass = "";

                if (validPass.Success)
                {
                    pass += validPass.Groups["nums"].Value;
                    pass += validPass.Groups["smal"].Value;
                    pass += validPass.Groups["big"].Value;
                    pass += validPass.Groups["simb"].Value;

                    Console.WriteLine($"Password: {pass}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
