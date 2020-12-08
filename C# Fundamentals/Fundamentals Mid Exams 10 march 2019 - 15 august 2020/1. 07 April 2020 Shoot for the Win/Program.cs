using System;
using System.Linq;

namespace _1._07_April_2020_Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] enemies = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string end = Console.ReadLine();
            int count = 0;

            while (end != "End")
            {
                int target = int.Parse(end);

                if (target >= 0 &&
                    target < enemies.Length && 
                    enemies[target] != -1)
                {
                    int curentTarget = enemies[target];
                    enemies[target] = -1;
                    count++;

                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] != -1 && enemies[i] > curentTarget)
                        {
                            enemies[i] -= curentTarget;
                        }
                        else if (enemies[i] != -1 && 
                            enemies[i] <= curentTarget)

                        {
                            enemies[i] += curentTarget;
                        }
                    }
                }
                end = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", enemies)}");
            
        }
    }
}
