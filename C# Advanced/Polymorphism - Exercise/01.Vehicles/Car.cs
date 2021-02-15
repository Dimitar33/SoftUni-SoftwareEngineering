using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehickle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
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
            FuelQuantity += fuel;
        }
    }
}
