using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    class Car
    {

        private string weight = "n/a";
        private string color = "n/a";


        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }
        
        
    }
}
