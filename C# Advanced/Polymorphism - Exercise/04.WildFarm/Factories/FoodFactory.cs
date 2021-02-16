using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class FoodFactory
    {
        public static Food CrateFood(string[] food)
        {
            int quantity = int.Parse(food[1]);

            switch (food[0])
            {
                case nameof(Vegetable):
                    return new Vegetable(quantity);

                case nameof(Meat):
                    return new Meat(quantity);

                case nameof(Seeds):
                    return new Seeds(quantity);

                case nameof(Fruit):
                    return new Fruit(quantity);

                default:
                    throw new Exception();
           
            }
        }
    }
}
