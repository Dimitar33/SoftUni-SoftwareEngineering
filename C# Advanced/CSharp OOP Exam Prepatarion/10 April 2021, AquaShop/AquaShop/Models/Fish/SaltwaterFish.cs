using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Contracts
{
    public class SaltwaterFish : Fish
    {
        private int size = 5;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }
        public override int Size => size;
        public override void Eat()
        {
            size += 2;
        }
        public override bool CanLeaveInAquarium(string aquariumType)
        {
            if (aquariumType == "SaltwaterAquarium")
            {
                return true;
            }
            return false;
        }
    }
}
