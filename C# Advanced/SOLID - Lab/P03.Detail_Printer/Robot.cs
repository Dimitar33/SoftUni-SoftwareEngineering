using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    internal class Robot : Employee
    {
        public Robot(string name, int batrety) : base(name)
        {
            Batrety = batrety;
        }

        public int Batrety { get; set; }
        public override string ToString()
        {
            return $"{Name}, batery left {Batrety}";
        }
    }
}
