using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
   public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("asda");
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}" ;
        }
    }
}
