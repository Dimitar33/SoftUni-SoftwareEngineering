﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods.Entities
{
    public class Cake : BakedFood
    {
        private const int portion = 245;
        public Cake(string name,  decimal price) 
            : base(name, portion, price)
        {
        }

       
    }
}
