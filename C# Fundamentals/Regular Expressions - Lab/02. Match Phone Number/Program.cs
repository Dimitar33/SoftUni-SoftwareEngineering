using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string register = Console.ReadLine();

            string regex = @"\+359([ -])2(\1)[0-9]{3}(\1)[0-9]{4}\b";

            var result = Regex.Matches(register, regex);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
