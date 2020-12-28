using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<Vloger> vlogers = new List<Vloger>();

            while (input[0] != "Statistics")
            {
                if (input[1] == "joined")
                {
                    if (!vlogers.Any(c => c.Name == input[0]))
                    {
                        Vloger vloger = new Vloger();

                        vloger.Name = input[0];
                        vloger.Followers = new SortedSet<string>();
                        vloger.Following = new HashSet<string>();

                        vlogers.Add(vloger);
                    }
                }
                else
                {
                    if (vlogers.Any(c => c.Name == input[0]) && vlogers.Any(c => c.Name == input[2]) && input[0] != input[2])
                    {
                        int index = vlogers.FindIndex(c => c.Name == input[2]);
                        int index2 = vlogers.FindIndex(c => c.Name == input[0]);

                        vlogers[index].Followers.Add(input[0]);
                        vlogers[index2].Following.Add(input[2]);

                    }
                }
                input = Console.ReadLine().Split();
            }

            vlogers = vlogers.OrderByDescending(c => c.Followers.Count).ThenBy(c => c.Following.Count).ToList();

            int count = 1;

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            var first = vlogers.First();
            vlogers.RemoveAt(0);

            Console.WriteLine($"{count}. {first.Name} : {first.Followers.Count} followers, {first.Following.Count} following");

            foreach (var item in first.Followers)
            {
                Console.WriteLine($"*  {item}");
            }

            foreach (var item in vlogers)
            {
                count++;

                Console.WriteLine($"{count}. {item.Name} : {item.Followers.Count} followers, {item.Following.Count} following");

            }

        }
        class Vloger
        {
            public string Name { get; set; }
            public SortedSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }
        }
    }
}
