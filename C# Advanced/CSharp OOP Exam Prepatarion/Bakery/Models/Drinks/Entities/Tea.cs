using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks.Entities
{
    public class Tea : Drink
    {
        public Tea(string name, int portion, string brand) : 
              base(name, portion, brand)
        {
        }

        public override decimal Price { get => 2.5m; }
    }
}
