using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public double Drive(double distance)
        {
            if (FuelConsumption * distance <= FuelQuantity)
            {
                FuelQuantity -= FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            return FuelQuantity;
        }
        public void WhoAmI(Car car)
        {
            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nFuel: {car.FuelQuantity:F2}L");
        }
    }
}
