using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n.Length; i++)
            {
                for (int j = i + 1; j < n.Length; j++)
                {
                    if (n[i] + n[j] == num)
                    {
                        Console.WriteLine($"{n[i]} {n[j]}");
                    }
                }

            }
        }
    }
}
