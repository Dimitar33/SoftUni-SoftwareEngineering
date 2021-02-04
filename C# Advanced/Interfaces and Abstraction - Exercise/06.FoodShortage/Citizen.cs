using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Citizen : Human, IBuyer
    {
        public Citizen(string name, string age, string id, string birthday) : base(name, age)
        {
            Id = id;
            Birthday = birthday;
        }

        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
