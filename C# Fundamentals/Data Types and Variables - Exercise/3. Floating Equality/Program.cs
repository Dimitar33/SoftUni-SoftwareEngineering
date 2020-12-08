using System;

namespace _3._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());

            decimal eps = 0.000001M;
            decimal sum = (decimal)Math.Abs(a - b);

            if (sum < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
