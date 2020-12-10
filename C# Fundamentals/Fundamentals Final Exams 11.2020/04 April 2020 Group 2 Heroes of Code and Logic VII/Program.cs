using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_April_2020_Group_2_Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroData = Console.ReadLine().Split();

                Hero hero = new Hero();
                hero.Name = heroData[0];
                hero.HP = int.Parse(heroData[1]);
                hero.MP = int.Parse(heroData[2]);

                heroes.Add(hero);
            }

            string[] cmd = Console.ReadLine().Split(" - ");

            while (cmd[0] != "End")
            {
                int dmg = int.Parse(cmd[2]);
                int name = heroes.FindIndex(c => c.Name == cmd[1]);

                switch (cmd[0])
                {
                    case "CastSpell":

                        if (heroes[name].MP >= dmg)
                        {
                            heroes[name].MP -= dmg;

                            Console.WriteLine($"{cmd[1]} has successfully cast {cmd[3]} and now has {heroes[name].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{cmd[1]} does not have enough MP to cast {cmd[3]}!");
                        }
                        break;
                    case "TakeDamage":

                        heroes[name].HP -= dmg;

                        if (heroes[name].HP > 0)
                        {
                            Console.WriteLine($"{cmd[1]} was hit for {dmg} HP by {cmd[3]} and now has {heroes[name].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{cmd[1]} has been killed by {cmd[3]}!");
                            heroes.RemoveAt(name);
                        }
                        break;
                    case "Recharge":

                        int manaRecovored = 0;

                        if (heroes[name].MP + dmg > 200)
                        {
                            manaRecovored = 200 - heroes[name].MP;
                            heroes[name].MP = 200;
                        }
                        else
                        {
                            heroes[name].MP += dmg;
                            manaRecovored = dmg;
                        }

                        Console.WriteLine($"{cmd[1]} recharged for {manaRecovored} MP!");

                        break;
                    case "Heal":

                        int healthRecovored = 0;

                        if (heroes[name].HP + dmg > 100)
                        {
                            healthRecovored = 100 - heroes[name].HP;
                            heroes[name].HP = 100;
                        }
                        else
                        {
                            heroes[name].HP += dmg;
                            healthRecovored = dmg;
                        }

                        Console.WriteLine($"{cmd[1]} healed for {healthRecovored} HP!");

                        break;
                    default:
                        break;
                }

                cmd = Console.ReadLine().Split(" - ");
            }
            heroes = heroes.OrderByDescending(c => c.HP).ThenBy(c => c.Name).ToList();

            foreach (var item in heroes)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"  HP: {item.HP}");
                Console.WriteLine($"  MP: {item.MP}");
            }

        }
        class Hero
        {
            public string Name { get; set; }
            public int HP { get; set; }
            public int MP { get; set; }
        }
    }
}
