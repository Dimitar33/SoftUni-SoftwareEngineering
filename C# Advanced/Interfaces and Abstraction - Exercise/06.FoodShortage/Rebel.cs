using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage 
{
    public class Rebel : Human, IBuyer
    {
       

        public Rebel(string name, string age, string group) : base(name, age)
        {
            Group = group;
        }
   
        public string Group { get; set; }
        public int Food { get ; set ; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
