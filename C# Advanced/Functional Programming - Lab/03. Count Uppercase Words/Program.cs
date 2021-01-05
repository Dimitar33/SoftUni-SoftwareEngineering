using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Func<string, bool> upper = c => Char.IsUpper(c[0]);

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(upper).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
