using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            List<Animal> animals = new List<Animal>();

            while (cmd[0] != "End")
            {

                Animal animal = AnimalFactorie.CreateAnimal(cmd);

                animals.Add(animal);
             
                string[] feed = Console.ReadLine().Split();

                Food food = FoodFactory.CrateFood(feed);

                animal.AskForFood();
                animal.Feed(food);

                cmd = Console.ReadLine().Split();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
