using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
   public class Tesla : IElectricCar , ICar
    {
        public Tesla(string model, string color, int batery)
        {
            Batery = batery;
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Batery { get; set ; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Batery} bateries\n{Start()}\n{Stop()}";
        }

    }
}
