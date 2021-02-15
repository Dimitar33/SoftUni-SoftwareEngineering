using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehickle
    {
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
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
            if (fuel + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                FuelQuantity += fuel * 0.95;
            }
        }
    }
}
