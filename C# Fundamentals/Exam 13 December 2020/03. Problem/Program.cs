using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(":");

            List<Unit> units = new List<Unit>();

            while (data[0] != "Results")
            {
                switch (data[0])
                {
                    case "Add":

                        int person = units.FindIndex(c => c.Name == data[1]);

                        if (person == -1)
                        {
                            Unit unit = new Unit();
                            unit.Name = data[1];
                            unit.Health = int.Parse(data[2]);
                            unit.Energy = int.Parse(data[3]);
                            
                            units.Add(unit);
                        }
                        else
                        {
                            units[person].Health += int.Parse(data[2]);
                        }
                        break;
                    case "Attack":

                        if (units.Exists(c => c.Name == data[1] &&
                            units.Exists(c => c.Name == data[2])))
                        {
                            int attacker = units.FindIndex(c => c.Name == data[1]);
                            int defender = units.FindIndex(c => c.Name == data[2]);
                            units[defender].Health -= int.Parse(data[3]);
                            units[attacker].Energy -= 1;

                            if (units[defender].Health < 1)
                            {
                                units.RemoveAt(defender);
                                Console.WriteLine($"{data[2]} was disqualified!");
                            }
                            attacker = units.FindIndex(c => c.Name == data[1]);
                            if (units[attacker].Energy < 1)
                            {
                                Console.WriteLine($"{data[1]} was disqualified!");
                                units.RemoveAt(attacker);
                            }
                        }

                        break;
                    case "Delete":

                        int index = units.FindIndex(c => c.Name == data[1]);
                        if (data[1] == "All")
                        {
                            units.Clear();
                        }
                        else if (index != -1)
                        {
                            units.RemoveAt(index);
                        }

                        break;

                    default:
                        break;
                }
                data = Console.ReadLine().Split(":");
            }

            units = units.OrderByDescending(c => c.Health).ThenBy(c => c.Name).ToList();

            Console.WriteLine($"People count: {units.Count}");

            foreach (var item in units)
            {
                Console.WriteLine($"{item.Name} - {item.Health} - {item.Energy}");
            }

        }
        class Unit
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Energy { get; set; }
        }
    }
}
