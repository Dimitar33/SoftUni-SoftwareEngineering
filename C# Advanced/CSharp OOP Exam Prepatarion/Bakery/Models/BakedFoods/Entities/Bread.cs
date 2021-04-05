﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods.Entities
{
    public class Bread : BakedFood
    {
        public Bread(string name, decimal price) : base(name, price)
        {
        }

        public override int Portion { get => 200; }
    }
}
