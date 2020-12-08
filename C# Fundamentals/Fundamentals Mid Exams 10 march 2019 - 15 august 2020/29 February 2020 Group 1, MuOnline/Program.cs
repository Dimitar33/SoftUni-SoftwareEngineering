using System;

namespace _29_February_2020_Group_1__MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split(new char[] { '|', ' ' });

            int health = 100;
            int gold = 0;
            int count = 0;

            for (int i = 0; i < rooms.Length; i += 2)
            {
                count++;

                if (rooms[i] == "potion")
                {

                    int healing = int.Parse(rooms[i + 1]);
                    health += healing;
                    if (health > 100)
                    {
                        Console.WriteLine($"You healed for {100 - (health - healing)} hp.");
                        health = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {healing} hp.");
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (rooms[i] == "chest")
                {
                    gold += int.Parse(rooms[i + 1]);
                    Console.WriteLine($"You found {int.Parse(rooms[i + 1])} bitcoins.");
                }
                else
                {
                    health -= int.Parse(rooms[i + 1]);
                    if (health < 1)
                    {
                        Console.WriteLine($"You died! Killed by {rooms[i]}.");
                        Console.WriteLine($"Best room: {count}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {rooms[i]}.");
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {gold}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
