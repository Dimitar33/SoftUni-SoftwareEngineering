using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Human : Birthdays
    {
        public Human(string name, string age, string id, string birthday)
        {
            Ids = id;
            Name = name;
            Age = age;
            Birthday = birthday;
        }

        public string Ids { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Birthday { get; set; }
    }
}
