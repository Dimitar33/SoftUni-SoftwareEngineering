using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> names = c => Console.WriteLine
            (string.Join(Environment.NewLine, c.Select(c => $"Sir {c}")));

            names(input);
        }
    }
}
