using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    class Pet
    {
        public Pet(string name, int age, string ownerr)
        {
            Name = name;
            Age = age;
            Owner = ownerr;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
