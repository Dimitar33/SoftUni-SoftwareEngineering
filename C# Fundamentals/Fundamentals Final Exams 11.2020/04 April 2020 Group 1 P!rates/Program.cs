using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_April_2020_Group_1_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialCities = Console.ReadLine().Split("||");
            List<City> cities = new List<City>();


            while (initialCities[0] != "Sail")
            {
                if (cities.Any(c => c.Name == initialCities[0]))
                {
                    int index = cities.FindIndex(c => c.Name == initialCities[0]);
                    cities[index].Pop += int.Parse(initialCities[1]);
                    cities[index].Gold += int.Parse(initialCities[2]);
                }
                else
                {
                    City city = new City();
                    city.Name = initialCities[0];
                    city.Pop = int.Parse(initialCities[1]);
                    city.Gold = int.Parse(initialCities[2]);

                    cities.Add(city);
                }
                initialCities = Console.ReadLine().Split("||");
            }
            string[] cmd = Console.ReadLine().Split("=>");

            while (cmd[0] != "End")
            {
                if (cmd[0] == "Plunder")
                {
                    int index = cities.FindIndex(c => c.Name == cmd[1]);
                    cities[index].Pop -= int.Parse(cmd[2]);
                    cities[index].Gold -= int.Parse(cmd[3]);

                    Console.WriteLine($"{cities[index].Name} plundered! {cmd[3]} gold stolen, {cmd[2]} citizens killed.");

                    if (cities[index].Gold < 1 || cities[index].Pop < 1)
                    {
                        Console.WriteLine($"{cities[index].Name} has been wiped off the map!");
                        cities.RemoveAt(index);
                    }

                }
                else
                {
                    if (int.Parse(cmd[2]) < 1)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                    }
                    else
                    {
                        int index = cities.FindIndex(c => c.Name == cmd[1]);
                        cities[index].Gold += int.Parse(cmd[2]);

                        Console.WriteLine($"{cmd[2]} gold added to the city treasury. {cities[index].Name} now has {cities[index].Gold} gold.");
                    }
                }

                cmd = Console.ReadLine().Split("=>");
            }
            cities = cities.OrderByDescending(c => c.Gold).ThenBy(c => c.Name).ToList();
            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (City item in cities)
                {
                    Console.WriteLine($"{item.Name} -> Population: {item.Pop} citizens, Gold: {item.Gold} kg");
                }
            }

        }
        class City
        {
            public string Name { get; set; }
            public int Pop { get; set; }
            public int Gold { get; set; }
        }
    }
}
