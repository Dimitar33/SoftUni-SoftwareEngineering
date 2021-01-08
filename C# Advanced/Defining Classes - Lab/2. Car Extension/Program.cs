using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            

            Car car = new Car();

            car.Make = "BMW";
            car.Model = "X3";
            car.Year = 12;
            car.FuelQuantity = 211;
            car.FuelConsumption = 12;

            car.Drive(11);
            car.WhoAmI(car); 

           // Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
