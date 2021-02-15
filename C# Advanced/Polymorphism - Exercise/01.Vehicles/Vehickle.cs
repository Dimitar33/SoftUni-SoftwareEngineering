using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehickle
    {
        protected Vehickle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public abstract void Refuel(double fuel);
        public abstract void Drive(double distance);


    }
}
