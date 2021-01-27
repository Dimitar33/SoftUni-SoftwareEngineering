using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car = new SportCar(122, 55);

            Console.WriteLine(car.Fuel);

            car.Drive(100);
            Console.WriteLine(car.FuelConsumption);
            Console.WriteLine(car.Fuel);

            Vehicle motor = new FamilyCar(122, 55);

            Console.WriteLine(motor.Fuel);

            motor.Drive(100);
            Console.WriteLine(motor.FuelConsumption);
            Console.WriteLine(motor.Fuel);
        }
    }
}
