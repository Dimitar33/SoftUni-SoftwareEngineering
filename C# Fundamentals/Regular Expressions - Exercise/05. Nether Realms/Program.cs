using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string namesplit = @"[^, ]+";
            // string healthForge = @"[^-+\/*.0-9]";
            //string dpsForge = @"[+-]{0,1}\d+\.*\d*";

            
            List<Demon> demons = new List<Demon>();

            List<Match> namesList = Regex.Matches(input, namesplit).ToList();

            foreach (Match item in namesList)
            {
                int health = 0;
                var multipliers = Regex.Matches(item.ToString(), @"[\/*]{1}").ToList();
                var healthForge = Regex.Matches(item.ToString(), @"[^-+\/*.0-9]").ToList();
                var dpsForge = Regex.Matches(item.ToString(), @"[+-]{0,1}\d+\.*\d*").Select(c => double.Parse(c.Value)).ToList().Sum();
                Demon demon = new Demon();

                foreach (var i in multipliers)
                {
                    if (i.Value == "/")
                    {
                        dpsForge /= 2;
                    }
                    else if (i.Value == "*")
                    {
                        dpsForge *= 2;
                    }
                }
                
                for (int i = 0; i < healthForge.Count; i++)
                {
                    health += char.Parse(healthForge[i].Value);
                }

                demon.Health = health;
                demon.Name = item.Value;
                demon.Damage = dpsForge;

                demons.Add(demon);
            }

            foreach (var item in demons.OrderBy(c => c.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Health} health, {item.Damage:f2} damage ");
            }

        }
        class Demon
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }
        }
    }
}
