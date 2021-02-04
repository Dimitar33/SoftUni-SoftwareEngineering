using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    class Pet : Birthdays
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get;set; }
    }
}
