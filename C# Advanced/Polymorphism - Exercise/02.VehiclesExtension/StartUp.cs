using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));

            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));

            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

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
                    else if (cmd[1] == "Bus")
                    {
                        bus.Drive(num);
                    }
                    else
                    {
                        truck.Drive(num);
                    }
                }
                else if(cmd[0] =="Refuel")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(num);
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Refuel(num);
                    }
                    else
                    {
                        truck.Refuel(num);
                    }
                }
                else
                {
                    bus.DriveEmpty(num);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");




        }
    }
}
