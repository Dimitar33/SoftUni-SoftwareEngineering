using System;
using System.Collections.Generic;

namespace _04._Raw_Data
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
                car.Speed = int.Parse(data[1]);
                car.Power = int.Parse(data[2]);
                car.Weight = int.Parse(data[3]);
                car.Type = data[4];

                cars.Add(car);
               
            }
            string cmd = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                if (cmd == "fragile" && cars[i].Weight < 1000)
                {
                    Console.WriteLine(cars[i].Model);
                }
                else if (cmd == "flamable" && cars[i].Power > 250)
                {
                    Console.WriteLine(cars[i].Model);
                }
            }
        }

        class Car
        {

            public string Model { get; set; }
            public int Speed { get; set; }
            public int Power { get; set; }
            public int Weight { get; set; }
            public string Type { get; set; }


        }
    }
}
