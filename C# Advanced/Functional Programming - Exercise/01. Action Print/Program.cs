using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string[]> names = c => Console.WriteLine(string.Join(Environment.NewLine, c));

            names(input);
        }
    }
}
