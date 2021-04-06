using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks.Entities
{
    public class Tea : Drink
    {
        private const decimal price = 2.5m;
        public Tea(string name, int portion, string brand) : 
              base(name, portion,price, brand)
        {
        }

       
    }
}
