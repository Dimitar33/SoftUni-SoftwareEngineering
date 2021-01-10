using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    class Engine
    {
        private string displacement = "n/a";
        private string efficiency = "n/a";


        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement
        {
            get
            {
                return displacement;
            }
            set
            {
                displacement = value;
            }
        }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        
    }
}
