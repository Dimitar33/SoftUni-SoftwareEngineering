using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] n2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n1.Length; i++)
            {
                if (n1[i] != n2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    Environment.Exit(0);
                }

            }


            Console.WriteLine($"Arrays are identical. Sum: {n1.Sum()}");

        }
    }
}
