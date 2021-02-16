using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override List<Type> FavoriteFoods => new List<Type> {typeof(Meat), typeof(Fruit),typeof(Seeds),typeof(Vegetable) };

        public override double Gain => 0.35;

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
    }
}
