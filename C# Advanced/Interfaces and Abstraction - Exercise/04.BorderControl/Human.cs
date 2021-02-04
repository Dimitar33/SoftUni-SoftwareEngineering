using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Human : IDs
    {
        public Human(string name, string age, string id)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
