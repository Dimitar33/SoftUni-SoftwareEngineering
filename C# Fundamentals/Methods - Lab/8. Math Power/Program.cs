using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double degree = double.Parse(Console.ReadLine());

            double result =  calculate(num, degree);

            Console.WriteLine(result);
        }

        private static double calculate(double num, double degree)
        {
            double result = Math.Pow(num, degree);

            return result;
        }
    }
}
