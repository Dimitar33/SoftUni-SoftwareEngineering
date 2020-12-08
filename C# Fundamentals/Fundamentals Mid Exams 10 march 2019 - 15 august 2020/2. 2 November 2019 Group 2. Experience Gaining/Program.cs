using System;

namespace _2._2_November_2019_Group_2._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExp = double.Parse(Console.ReadLine());
            double battlesCount = double.Parse(Console.ReadLine());
            int battles = 0;

            for (int i = 1; i <= battlesCount; i++)
            {
                double expPerBattle = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    expPerBattle *= 1.15;
                }
                if (i % 5 == 0)
                {
                    expPerBattle *= 0.9;
                }
                neededExp -= expPerBattle;
                battles++;

                if (neededExp <= 0)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine($"Player was not able to collect the needed experience, {neededExp:f2} more needed.");
        }
    }
}
