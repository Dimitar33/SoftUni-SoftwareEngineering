using System;

namespace Mid_Exam_Retake___07_April_2020_Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string end = Console.ReadLine();
            int wins = 0;

            while (end != "End of battle")
            {
                int distnace = int.Parse(end);

                energy -= distnace;

                if (energy < 0)
                {
                    energy += distnace;
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    Environment.Exit(0);
                }
                wins++;
                if (wins % 3 == 0)
                {
                    energy += wins;
                }
                end = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
        }
    }
}
