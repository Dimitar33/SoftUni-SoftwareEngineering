using System;

namespace _4._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());


            Console.WriteLine(Factorial(num, 1));
        }

        private static int Factorial(int num, int n)
        {
            if (n >= num)
            {
                return n;
            }

            return n * Factorial(num, n + 1);
        }
    }
}
