using System;

namespace _2._10_December._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double jurneyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double savings = 0;

            for (int i = 1; i <= months; i++)
            {

                if (i > 1 && i % 2 != 0)
                {
                    savings *= 0.84;
                }
                if (i > 0 && i % 4 == 0)
                {
                    savings *= 1.25;
                }

                savings += jurneyCost * 0.25;

            }
            double diff = Math.Abs(savings - jurneyCost);

            if (savings >= jurneyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {diff:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {diff:f2}lv. more.");
            }
        }
    }
}
