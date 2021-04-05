using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods.Entities
{
    public class Cake : BakedFood
    {
        public Cake(string name,  decimal price) : base(name, price)
        {
        }

        public override int Portion { get => 245;  }
    }
}
