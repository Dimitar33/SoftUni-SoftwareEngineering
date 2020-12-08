using System;

namespace _1._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());

            int sum = ((n1 + n2) / n3) * n4;

            Console.WriteLine(sum);
        }
    }
}
