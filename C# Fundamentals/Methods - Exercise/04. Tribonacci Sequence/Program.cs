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
            if (n > 2)
            {
                fibonaci[2] = 2;
            }

            if (n > 2)
            {
                for (int i = 3; i < n; i++)
                {
                    fibonaci[i] = fibonaci[i - 1] + fibonaci[i - 2] + fibonaci[i -3];
                }
            }

            Console.WriteLine(string.Join (" ", fibonaci));
        }
    }
}
