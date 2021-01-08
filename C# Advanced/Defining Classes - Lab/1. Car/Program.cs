using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();

            Car car = new Car();

            car.Make = carData[0];
            car.Model = carData[1];
            car.Year = int.Parse(carData[2]);

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");


        }
       
    }
}
