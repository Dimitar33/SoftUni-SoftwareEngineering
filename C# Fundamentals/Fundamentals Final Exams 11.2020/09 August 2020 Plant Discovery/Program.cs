using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_August_2020_Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] initialPlants = Console.ReadLine().Split("<->");

                Plant plant = new Plant();
                plant.Name = initialPlants[0];
                plant.Rarity = int.Parse(initialPlants[1]);
                plant.Rating = 0;

                if (plants.Exists(c => c.Name == initialPlants[0]))
                {
                    int index = plants.FindIndex(c => c.Name == initialPlants[0]);
                    plants[index].Rarity = int.Parse(initialPlants[1]);
                }
                else
                {
                    plants.Add(plant);
                }
            }

            string[] cmd = Console.ReadLine().Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "Exhibition")
            {
                

                switch (cmd[0])
                {
                    case "Rate":
                        int index = plants.FindIndex(c => c.Name == cmd[1]);
                        if (plants[index].Rating == 0)
                        {
                            plants[index].Rating = int.Parse(cmd[2]);
                        }
                        else
                        {
                            plants[index].Rating = (plants[index].Rating + int.Parse(cmd[2]))* 1.0 / 2;
                        }

                        break;
                    case "Update":
                        int index1 = plants.FindIndex(c => c.Name == cmd[1]);
                        plants[index1].Rarity = int.Parse(cmd[2]);

                        break;
                    case "Reset":
                        int index2 = plants.FindIndex(c => c.Name == cmd[1]);
                        plants[index2].Rating = 0;

                        break;
                    default:

                        Console.WriteLine("error");
                        break;
                }
                cmd = Console.ReadLine().Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
            }
            plants = plants.OrderByDescending(c => c.Rarity).
                            ThenByDescending(c => c.Rating).ToList();

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in plants)
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.Rating:f2}");
            }

        }
        class Plant
        {
            public string Name { get; set; }
            public double Rarity { get; set; }
            public double Rating { get; set; }
        }
    }
}
