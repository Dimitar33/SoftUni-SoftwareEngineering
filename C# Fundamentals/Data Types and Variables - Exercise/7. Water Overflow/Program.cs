using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacitu = 255;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (liters > capacitu)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                sum += liters;
                capacitu -= liters;
            }
            Console.WriteLine(sum);
        }
    }
}
