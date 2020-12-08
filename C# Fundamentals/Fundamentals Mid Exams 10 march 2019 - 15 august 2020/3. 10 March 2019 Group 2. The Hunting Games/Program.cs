using System;

namespace _3._10_March_2019_Group_2._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double playersCount = double.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double water = waterPerPerson * playersCount * days;
            double food = foodPerPerson * playersCount * days;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                groupsEnergy -= energyLoss;
                if (groupsEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");

                    Environment.Exit(0);
                }
                if (i % 2 == 0)
                {
                    groupsEnergy *= 1.05;
                    water *= 0.7;
                }
                if (i % 3 == 0)
                {
                    groupsEnergy *= 1.1;
                    food -= food / playersCount;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");
        }
    }
}
