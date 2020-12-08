using System;

namespace _2._6_August_2019._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder / 2;
                }
                totalPlunder += dailyPlunder;
                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");

            }
            else
            {
                double percent = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percent:f2}% of the plunder.");
            }
        }
    }
}
