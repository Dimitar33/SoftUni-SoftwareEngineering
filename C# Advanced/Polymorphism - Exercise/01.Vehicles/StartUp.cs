using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                double num = double.Parse(cmd[2]);

                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Drive(num);
                    }
                    else
                    {
                        truck.Drive(num);
                    }
                }
                else
                {
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(num);
                    }
                    else
                    {
                        truck.Refuel(num);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");



        }
    }
}
