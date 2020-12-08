using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string regex = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";


            var result = Regex.Matches(names , regex);

            foreach (Match item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}
