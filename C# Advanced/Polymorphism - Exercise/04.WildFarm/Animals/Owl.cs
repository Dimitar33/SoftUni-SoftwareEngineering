using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override List<Type> FavoriteFoods => new List<Type> {typeof(Meat) };

        public override double Gain => 0.25;

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
