using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] garden = new int[n[0], n[1]];

            Dictionary<int, int> fwolers = new Dictionary<int, int>();

            string flowers = Console.ReadLine();

            while (flowers != "Bloom Bloom Plow")
            {
                int[] cmd = flowers.Split().Select(int.Parse).ToArray();

                

                fwolers.Add(cmd[0], cmd[1]);

                flowers = Console.ReadLine();

            }

            foreach (var item in fwolers)
            {
                if (item.Key < 0 || item.Key >= garden.GetLength(0) || item.Value < 0 || item.Value >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[item.Key, i]++;
                }
                
                int row = item.Value;

                for (int i = 0; i < garden.GetLength(1); i++)
                {
                    if (i == row )
                    {
                        continue;
                    }
                    garden[i, item.Value]++;
                }
            }

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
