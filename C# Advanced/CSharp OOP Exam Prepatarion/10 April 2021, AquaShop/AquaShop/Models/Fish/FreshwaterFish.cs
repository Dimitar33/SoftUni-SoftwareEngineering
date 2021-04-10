using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int size = 0;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }
        public override int Size => size;
        public override void Eat()
        {
            size += 3;
        }
        public override bool CanLeaveInAquarium(string aquariumType)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                return true;
            }
            return false;
        }

    }
}
