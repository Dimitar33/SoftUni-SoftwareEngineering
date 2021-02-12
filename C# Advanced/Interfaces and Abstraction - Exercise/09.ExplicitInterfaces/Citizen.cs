using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, string age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }

        string IPerson.GetName()
        {
            return Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
