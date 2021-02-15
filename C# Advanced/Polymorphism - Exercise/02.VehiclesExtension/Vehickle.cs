using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehickle
    {
        private double fuelQuantity;
        protected Vehickle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public int TankCapacity { get; }
        public double FuelQuantity
        { 
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }           
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }

        public abstract void Refuel(double fuel);
        public abstract void Drive(double distance);


    }
}
