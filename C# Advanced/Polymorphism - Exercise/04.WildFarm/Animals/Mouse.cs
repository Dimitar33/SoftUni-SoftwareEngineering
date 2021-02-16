using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override List<Type> FavoriteFoods => new List<Type> { typeof(Vegetable), typeof(Fruit) };

        public override double Gain => 0.1;

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }
    }
}
