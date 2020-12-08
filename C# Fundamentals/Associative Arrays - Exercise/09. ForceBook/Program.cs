using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] end = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var sides = new Dictionary<string, List<string>>();

            while (end[0] != "Lumpawaroo")
            {
                if (end.Contains("|"))
                {
                    string temp = string.Join(" ", end);
                    string[] cmd = temp.Split(" | ");

                    if (!sides.ContainsKey(cmd[0]))
                    {
                        sides.Add(cmd[0], new List<string>());
                    }
                    if (!sides.Any(c => c.Value.Contains(cmd[1])))
                    {
                        sides[cmd[0]].Add(cmd[1]);
                    }
                }
                else if (end.Contains("->"))
                {
                    string temp = string.Join(" ", end);
                    string[] cmd = temp.Split(" -> ");
                    if (!sides.ContainsKey(cmd[1]))
                    {
                        sides.Add(cmd[1], new List<string>());
                    }
                    if (sides.Any(c => c.Value.Contains(cmd[0])))
                    {
                        sides.Any(c => c.Value.Remove(cmd[0]));
                        sides[cmd[1]].Add(cmd[0]);
                    }
                    else
                    {
                        sides[cmd[1]].Add(cmd[0]);
                    }
                    Console.WriteLine($"{cmd[0]} joins the {cmd[1]} side!");
                }
                end = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            sides = sides.OrderByDescending(c => c.Value.Count).ThenBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in sides)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                }
                foreach (var i in item.Value.OrderBy(c => c))
                {
                    Console.WriteLine($"! {i}");
                }
            }
        }
    }
}
