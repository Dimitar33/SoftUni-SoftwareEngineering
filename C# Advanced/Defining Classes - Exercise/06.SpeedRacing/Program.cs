using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelPerKm = double.Parse(carData[2]);
                double distance = 0;

                Car car = new Car(model, fuelAmount, fuelPerKm, distance);

                cars.Add(car);
            }

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                string model = cmd[1];                       
                double distance = double.Parse(cmd[2]);

                cars.First(c => c.Model == model).Drive(distance);

                cmd = Console.ReadLine().Split();
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.DistanceTraveled}");
            }
        }
    }
}
