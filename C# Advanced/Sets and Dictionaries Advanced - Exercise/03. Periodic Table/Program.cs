using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> table = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Split();

                for (int j = 0; j < element.Length; j++)
                {
                    table.Add(element[j]);

                }
            }

            Console.WriteLine(string.Join(" ", table.OrderBy(c => c)));
        }
    }
}
