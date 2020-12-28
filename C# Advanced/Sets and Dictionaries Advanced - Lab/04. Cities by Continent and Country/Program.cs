using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (continents.ContainsKey(data[0]))
                {
                    if (continents[data[0]].ContainsKey(data[1]))
                    {
                        continents[data[0]][data[1]].Add(data[2]);
                    }
                    else
                    {
                        continents[data[0]].Add(data[1], new List<string>());
                        continents[data[0]][data[1]].Add(data[2]);
                    }

                }
                else
                {
                    continents.Add(data[0], new Dictionary<string, List<string>>());
                    continents[data[0]].Add(data[1], new List<string>());
                    continents[data[0]][data[1]].Add(data[2]);
                }
            }

            foreach (var item in continents)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($" {product.Key} -> {string.Join(", ", product.Value)}");
                }
            }
        }
    }
}
