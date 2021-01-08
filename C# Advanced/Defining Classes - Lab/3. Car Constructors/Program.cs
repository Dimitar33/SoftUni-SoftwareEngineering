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
            car.FuelQuantity = double.Parse(carData[3]);
            car.FuelConsumption = double.Parse(carData[4]);

            Car firstCar = new Car();

            Car secondCar = new Car(carData[0], carData[1], int.Parse(carData[2]));

            Car thirdCar = new Car(carData[0], carData[1], int.Parse(carData[2]),
                double.Parse(carData[3]), double.Parse(carData[4]));

            car.WhoAmI(firstCar);
            car.WhoAmI(secondCar);
            car.WhoAmI(thirdCar);
        }
    }
}
