using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
 
        public override List<Type> FavoriteFoods => new List<Type> { typeof(Meat) };

        public override double Gain => 0.4;

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

       
    }
}
