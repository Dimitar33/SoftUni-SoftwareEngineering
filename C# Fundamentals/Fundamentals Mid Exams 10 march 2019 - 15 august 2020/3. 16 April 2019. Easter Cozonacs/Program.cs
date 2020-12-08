using System;

namespace _3._16_April_2019._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());

            double eggPrice = flourPrice * 0.75;
            double milkPrice = flourPrice * 1.25 / 4;
            double cozunkPrice = flourPrice + eggPrice + milkPrice;
            int count = 0;
            double coloredEggs = 0;

            while (budget >= cozunkPrice)
            {
                count++;
                coloredEggs += 3;
                if (count % 3 == 0)
                {
                    coloredEggs -= count - 2;
                }
                budget -= cozunkPrice;
            }
            Console.WriteLine($"You made {count} cozonacs! Now you have {coloredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
