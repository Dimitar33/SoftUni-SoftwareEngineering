using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] kube = new int[n, n];
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    kube[i, j] = input[j];
                }
            }
            for (int i = 0; i < kube.GetLength(1); i++)
            {
                sum1 += kube[i, i];
            }
            for (int i = 0; i < kube.GetLength(1); i++)
            {
                sum2 += kube[i, kube.GetLength(1) - i -1];
            }
            int total = Math.Abs(sum1 - sum2);
            Console.WriteLine(total);
        }
    }
}
