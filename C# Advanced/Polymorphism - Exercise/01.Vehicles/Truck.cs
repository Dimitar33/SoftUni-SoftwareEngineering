using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehickle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption + 1.6);

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel * 0.95;
        }
    }
}
