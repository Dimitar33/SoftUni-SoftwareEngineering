using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehickle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption + 1.4);

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption);

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
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
                FuelQuantity += fuel;
            }
        }
    }
}
