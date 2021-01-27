using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private static string gender = "Female";
        public Kitten(string name ,int age, string gen) : base (name , age , gender)
        {

        }
        public Kitten(string name, int age) : base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
             return "Meow";
        }
    }
}
