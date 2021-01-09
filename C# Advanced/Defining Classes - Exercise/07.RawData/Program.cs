using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
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
                int engnSpeed = int.Parse(carData[1]);
                int engnPowe = int.Parse(carData[2]);
                int cargoW = int.Parse(carData[3]);
                string cargoT = carData[4];            

                Tires[] tire = new Tires[]
                {
                   new Tires(double.Parse(carData[5]), int.Parse(carData[6])),
                   new Tires(double.Parse(carData[7]), int.Parse(carData[8])),
                   new Tires(double.Parse(carData[9]), int.Parse(carData[10])),
                   new Tires(double.Parse(carData[11]), int.Parse(carData[12])),

                };

                Engine engine = new Engine(engnSpeed, engnPowe);
                Cargo cargo = new Cargo(cargoT, cargoW);

                Car car = new Car(model, engine, cargo, tire);

                cars.Add(car);
            }
            string fragOrFlame = Console.ReadLine();

            if (fragOrFlame == "fragile")
            {
               cars = cars.Where(c => c.Cargo.CargoType == "fragile" && 
                                 c.Tires.Any(c => c.Pressure < 1)).ToList();
            }
            else
            {
                cars = cars.Where(c => c.Cargo.CargoType == "flamable" &&
                                  c.Engine.EnginePower > 250).ToList();
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
