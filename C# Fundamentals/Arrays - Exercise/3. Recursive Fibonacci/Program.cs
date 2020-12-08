using System;

namespace _3._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] fibonaci = new int[n];

            fibonaci[0] = 1;

            if (n > 1)
            {
                fibonaci[1] = 1;
            }

            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                {
                    fibonaci[i] = fibonaci[i - 1] + fibonaci[i - 2];
                }
            }

            Console.WriteLine(fibonaci[fibonaci.Length - 1]);
        }
    }
}
