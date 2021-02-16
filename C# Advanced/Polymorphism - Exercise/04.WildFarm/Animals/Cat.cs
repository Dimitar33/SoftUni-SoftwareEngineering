using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> FavoriteFoods => new List<Type> {typeof(Vegetable), typeof(Meat) };

        public override double Gain => 0.3;

        public override void AskForFood()
        {
            Console.WriteLine("Meow");      
        }
    }
}
