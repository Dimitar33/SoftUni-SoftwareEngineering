using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_April_2020_Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split("|");

                Car car = new Car();
                car.Name = carData[0];
                car.Mileage = int.Parse(carData[1]);
                car.Fuel = int.Parse(carData[2]);

                cars.Add(car);
            }

            string[] cmd = Console.ReadLine().Split(" : ");

            while (cmd[0] != "Stop")
            {
                int carIndex = cars.FindIndex(c => c.Name == cmd[1]);
                int cmd2 = int.Parse(cmd[2]);

                switch (cmd[0])
                {
                    case "Drive":

                        if (cars[carIndex].Fuel >= int.Parse(cmd[3]))
                        {
                            cars[carIndex].Fuel -= int.Parse(cmd[3]);
                            cars[carIndex].Mileage += cmd2;

                            Console.WriteLine($"{cars[carIndex].Name} driven for {cmd2} kilometers. {int.Parse(cmd[3])} liters of fuel consumed.");

                            if (cars[carIndex].Mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {cars[carIndex].Name}!");
                                cars.Remove(cars[carIndex]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        break;
                    case "Refuel":

                        if (cars[carIndex].Fuel + cmd2 > 75)
                        {
                            Console.WriteLine($"{cars[carIndex].Name} refueled with {75 - cars[carIndex].Fuel} liters");
                            cars[carIndex].Fuel = 75;
                        }
                        else
                        {
                            cars[carIndex].Fuel += cmd2;
                            Console.WriteLine($"{cars[carIndex].Name} refueled with {cmd2} liters");
                        }

                        break;
                    case "Revert":

                        if (cars[carIndex].Mileage - cmd2 >= 10000)
                        {
                            Console.WriteLine($"{cars[carIndex].Name} mileage decreased by {cmd2} kilometers");
                            cars[carIndex].Mileage -= cmd2;
                        }
                        else
                        {
                            cars[carIndex].Mileage = 10000;
                        }

                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(" : ");
            }
            cars = cars.OrderByDescending(c => c.Mileage).ThenBy(c => c.Name).ToList();

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Name} -> Mileage: {item.Mileage} kms, Fuel in the tank: {item.Fuel} lt.");
            }
        }

        class Car
        {
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}
