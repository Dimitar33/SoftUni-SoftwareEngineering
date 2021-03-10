using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private int minHorsePower = 400;
        private int maxHorsePower = 600;
        private int horsePower;

        public MuscleCar(string model, int horsePower) : base(model, horsePower)
        {
        }

        public override double CubicCentimeters => 5000;

        public override int HorsePower 
        { 
            get => horsePower; 
            set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value;
            }
        }
    }
}
