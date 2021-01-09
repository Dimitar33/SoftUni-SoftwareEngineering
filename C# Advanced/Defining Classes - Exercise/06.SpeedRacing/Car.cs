using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelPerKm, double distance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelPerKm = fuelPerKm;
            DistanceTraveled = distance;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPerKm { get; set; }
        public double DistanceTraveled { get; set; }

        public double Drive(double distance)
        {           

            if (distance * FuelPerKm > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distance * FuelPerKm;
                DistanceTraveled += distance;
            }
           
            return FuelAmount;
        }
    }
}
