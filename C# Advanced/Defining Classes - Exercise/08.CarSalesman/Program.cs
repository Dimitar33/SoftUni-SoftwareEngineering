using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engnData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine();

                engine.Model = engnData[0];
                engine.Power = engnData[1];

                if (engnData.Length == 3)
                {
                    int num;

                    if (int.TryParse(engnData[2], out num))
                    {
                        engine.Displacement = engnData[2];
                    }
                    else
                    {
                        engine.Efficiency = engnData[2];
                    }
                }
                else if (engnData.Length == 4)
                {
                    engine.Displacement = engnData[2];
                    engine.Efficiency = engnData[3];
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car();

                Engine engn = engines.First(c => c.Model == carData[1]);

                car.Model = carData[0];
                car.Engine = engn;

                if (carData.Length == 3)
                {
                    int num;

                    if (int.TryParse(carData[2], out num))
                    {
                        car.Weight = carData[2];
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }
                else if (carData.Length == 4)
                {
                    car.Weight = carData[2];
                    car.Color = carData[3];
                }

                cars.Add(car);
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model}:");
                Console.WriteLine($"  {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {item.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {item.Weight}");
                Console.WriteLine($"  Color: {item.Color}");
            }
        }
    }
}
