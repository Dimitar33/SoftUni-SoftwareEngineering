using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split("/");

            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();


            while (data[0] != "end")
            {
                if (data[0] == "Truck")
                {
                    Truck truck = new Truck();

                    truck.brand = data[1];
                    truck.model = data[2];
                    truck.weight = int.Parse(data[3]);

                    trucks.Add(truck);
                }
                else
                {
                    Car car = new Car();

                    car.brand = data[1];
                    car.model = data[2];
                    car.hPower = int.Parse(data[3]);

                    cars.Add(car);
                }

                data = Console.ReadLine().Split("/");
            }

            cars = cars.OrderBy(c => c.brand).ToList();

            Console.WriteLine("Cars:");

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.brand}: {car.model} - {car.hPower}hp");
            }

            trucks = trucks.OrderBy(c => c.brand).ToList();

            Console.WriteLine("Trucks:");

            foreach (Truck truck in trucks)
            {
                Console.WriteLine($"{truck.brand}: {truck.model} - {truck.weight}kg");
            }
        }
    }
    class Truck
    {
        public string brand { get; set; }
        public string model { get; set; }
        public int weight { get; set; }
    }
    class Car
    {
        public string brand { get; set; }
        public string model { get; set; }
        public int hPower { get; set; }
    }
}
