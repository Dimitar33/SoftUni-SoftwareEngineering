using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nM = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> numsN = new HashSet<int>();
            HashSet<int> numsM = new HashSet<int>();
            HashSet<int> repeated = new HashSet<int>();

            for (int i = 0; i < nM[0]; i++)
            {
                int numN = int.Parse(Console.ReadLine());
                numsN.Add(numN);
            }
            for (int i = 0; i < nM[1]; i++)
            {
                int numM = int.Parse(Console.ReadLine());

                numsM.Add(numM);
            }
            foreach (var item in numsN)
            {
                if (numsM.Contains(item))
                {
                    repeated.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", repeated));
        }
    }
}
