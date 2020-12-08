using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());

           double result = factorialDivision(n1, n2);

            Console.WriteLine($"{result:f2}");
        }

        private static double factorialDivision(double n1, double n2)
        {
            double factorial1 = 1;
            double factorial2 = 1;

            for (int i = 1; i <= n1; i++)
            {
                factorial1 *= i;
            }
            for (int i = 1; i <= n2; i++)
            {
                factorial2 *= i;
            }
            double sum = factorial1 / factorial2;

            return sum;
        }
    }
}
