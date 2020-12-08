using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Car car = new Car();

                car.Model = data[0];
                car.TankLimit = double.Parse(data[1]);
                car.FuelPerKm = double.Parse(data[2]);
                car.DistanceTraveled = 0;

                cars.Add(car);
            }

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                for (int i = 0; i < n; i++)
                {
                    if (cars[i].Model == cmd[1])
                    {
                        double fuelNeeded = cars[i].FuelPerKm * double.Parse(cmd[2]);
                        if (fuelNeeded <= cars[i].TankLimit)
                        {
                            cars[i].TankLimit -= fuelNeeded;
                            cars[i].DistanceTraveled += double.Parse(cmd[2]);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    } 
                }


                cmd = Console.ReadLine().Split();
            }

            foreach (Car item in cars)
            {
                Console.WriteLine($"{item.Model} {item.TankLimit:f2} {item.DistanceTraveled}");
            }
        }



        class Car
        {
            public string Model { get; set; }
            public double TankLimit { get; set; }
            public double FuelPerKm { get; set; }
            public double DistanceTraveled { get; set; }
            
            
        }

    }
}
