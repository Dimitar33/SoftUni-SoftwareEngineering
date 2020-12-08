using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mats = Console.ReadLine().ToLower().Split();

            var inventorie = new Dictionary<string, int>();
            string shards = "shards";
            string fragments = "fragments";
            string motes = "motes";
            inventorie.Add(shards, 0);
            inventorie.Add(fragments, 0);
            inventorie.Add(motes, 0);
            bool enough = true;


            while (enough)
            {
                for (int i = 1; i < mats.Length; i += 2)
                {
                    int resValue = int.Parse(mats[i - 1]);

                    if (inventorie.ContainsKey(mats[i]))
                    {
                        inventorie[mats[i]] += resValue;
                    }
                    else
                    {
                        inventorie.Add(mats[i], resValue);
                    }

                    if (inventorie[shards] >= 250)
                    {
                        inventorie[shards] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        enough = false;
                        break;
                    }
                    if (inventorie[fragments] >= 250)
                    {
                        inventorie[fragments] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        enough = false;
                        break;
                    }
                    if (inventorie[motes] >= 250)
                    {
                        inventorie[motes] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        enough = false;
                        break;
                    }
                }
                if (!enough)
                {
                    break;
                }

                mats = Console.ReadLine().ToLower().Split();
            }
            Dictionary<string, int> valuable = inventorie.Where(c => c.Key == "shards" || c.Key == "fragments" || c.Key == "motes").OrderByDescending(c => c.Value).ThenBy(c => c.Key).ToDictionary(c => c.Key , c => c.Value);

            Dictionary<string, int> junk = inventorie.Where(c => c.Key != "shards" && c.Key != "fragments" && c.Key != "motes").OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in valuable)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
