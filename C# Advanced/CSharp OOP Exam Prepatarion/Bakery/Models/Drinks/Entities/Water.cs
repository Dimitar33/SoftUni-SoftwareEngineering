using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks.Entities
{
    public class Water : Drink
    {
        public Water(string name, int portion, string brand) 
            : base(name, portion, brand)
        {
        }

        public override decimal Price { get => 1.5m; }
    }
}
