using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private static string gender = "Male";

        public Tomcat(string name, int age, string gen) : base (name, age , gender)
        {

        }

        public Tomcat(string name, int age) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
