using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private int horsePower;
        private int minHorsePower = 250;
        private int maxHorsePower = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower)
        {
        }

        public override double CubicCentimeters => 3000;

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
