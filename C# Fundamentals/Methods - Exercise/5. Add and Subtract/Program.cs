using System;
using System.Diagnostics.CodeAnalysis;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int suma = sum(n1, n2); 
            int result = substract(suma, n3);

            Console.WriteLine(result);
        }

        private static int substract(int suma, int n3)
        {
            int sum = suma - n3;

            return sum;
        }

        private static int sum(int n1, int n2)
        {
            int sum = n1 + n2;

            return sum;
        }
    }
}
