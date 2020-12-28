using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 1; j < clothes.Length; j++)
                {
                    if (!wardrobe.ContainsKey(clothes[0]))
                    {
                        wardrobe.Add(clothes[0], new Dictionary<string, int>());
                    }
                    if (!wardrobe[clothes[0]].ContainsKey(clothes[j]))
                    {
                        wardrobe[clothes[0]].Add(clothes[j], 1);
                    }
                    else
                    {
                        wardrobe[clothes[0]][clothes[j]]++;
                    }
                }
            }
            string[] needed = Console.ReadLine().Split();



            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothe in item.Value)
                {
                    if (item.Key == needed[0] && clothe.Key == needed[1])
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");

                    }
                }
            }
        }
    }
}
