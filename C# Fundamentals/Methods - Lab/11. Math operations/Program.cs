using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            string operaciq = Console.ReadLine();
            double n2 = double.Parse(Console.ReadLine());

            double result = calculator(n1, operaciq, n2);

            Console.WriteLine(result);
        }

        private static double calculator(double n1, string operaciq, double n2)
        {
            double result = 0;

            if (operaciq == "*")
            {
                result = n1 * n2;
            }
            if (operaciq == "/")
            {
                result = n1 / n2;
            }
            if (operaciq == "-")
            {
                result = n1 - n2;
            }
            if (operaciq == "+")
            {
                result = n1 + n2;
            }
            return result;
        }
    }
}
