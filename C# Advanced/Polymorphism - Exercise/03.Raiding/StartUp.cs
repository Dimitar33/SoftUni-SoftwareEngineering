using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raid = new List<BaseHero>();
            

            while (raid.Count != n)
            {

                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {

                    case "Druid":

                        Druid druid = new Druid(name);
                        raid.Add(druid);
                     

                        break;
                    case "Rogue":

                        Rogue rogue = new Rogue(name);
                        raid.Add(rogue);
                       

                        break;
                    case "Paladin":

                        Paladin pala = new Paladin(name);
                        raid.Add(pala);
                       

                        break;
                    case "Warrior":

                        Warrior warr = new Warrior(name);
                        raid.Add(warr);
                       

                        break;
                    default:

                        Console.WriteLine("Invalid hero!");

                        break;
                }

            }
            int bossHealth = int.Parse(Console.ReadLine());

            int dps = raid.Select(c => c.Power).Sum();
            foreach (var item in raid)
            {
                Console.WriteLine(item.CastAbility());
                dps += item.Power;
            }

            if (dps < bossHealth)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
