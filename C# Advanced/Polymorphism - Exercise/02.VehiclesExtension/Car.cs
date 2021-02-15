using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehickle
    {
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption + 0.9);

            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
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
