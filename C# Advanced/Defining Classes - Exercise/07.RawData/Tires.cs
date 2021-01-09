using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Tires
    {
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tires(double tirePressure, int tireAge)
        {
            Pressure = tirePressure;
            Age = tireAge;
        }
    }
}
