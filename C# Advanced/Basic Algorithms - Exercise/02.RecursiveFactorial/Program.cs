using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        public static int Factorial(int n)
        {

            if (n == 1)
            {
                return 1;
            }
            
            int sum = n * Factorial(n - 1);

            return sum;
        }
    }
}
