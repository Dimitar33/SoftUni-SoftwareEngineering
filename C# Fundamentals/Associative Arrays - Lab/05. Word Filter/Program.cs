using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().Where(c => c.Length % 2 == 0).ToList();

            Console.WriteLine(string.Join("\n", text));
        }
    }
}
