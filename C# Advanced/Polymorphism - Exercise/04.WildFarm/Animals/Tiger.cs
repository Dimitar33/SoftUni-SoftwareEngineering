using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> FavoriteFoods => new List<Type> { typeof(Meat) };

        public override double Gain => 1;

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
