using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract List<Type> FavoriteFoods { get; }
        public abstract void AskForFood();

        public abstract double Gain { get; }

        public void Feed(Food food)
        {
            if (!FavoriteFoods.Contains(food.GetType()))
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                FoodEaten += food.Quantity;
                Weight += Gain * food.Quantity;
            }
        }
    }
}
