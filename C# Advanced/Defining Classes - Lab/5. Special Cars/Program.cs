using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<string> tiresList = new List<string>();

            string tiresInput = Console.ReadLine();

            while (tiresInput != "No more tires")
            {
                tiresList.Add(tiresInput);

                tiresInput = Console.ReadLine();
            }

            List<string> engineList = new List<string>();

            string engineInput = Console.ReadLine();

            while (engineInput != "Engines done")
            {
                engineList.Add(engineInput);

                engineInput = Console.ReadLine();
            }

            List<Car> carList = new List<Car>();

            string carInput = Console.ReadLine();

            while (carInput != "Show special")
            {
                string[] carData = carInput.Split();
                
                Car car = new Car();

                car.Make = carData[0];
                car.Model = carData[1];
                car.Year = int.Parse(carData[2]);
                car.FuelQuantity = double.Parse(carData[3]);
                car.FuelConsumption = double.Parse(carData[4]);

                var currentEngine = engineList[int.Parse(carData[5])].Split();
                int enginePower = int.Parse(currentEngine[0]);
                double engineCC = double.Parse(currentEngine[1]);

                car.Engine = new Engine(enginePower, engineCC);

                //Engine engine = new Engine(enginePower, engineCC);

                string[] currentTires = tiresList[int.Parse(carData[6])].Split();

                car.Tires = new Tire[] 
                {
                 new Tire  (int.Parse(currentTires[0]), double.Parse(currentTires[1])),
                 new Tire  (int.Parse(currentTires[2]), double.Parse(currentTires[3])),
                 new Tire  (int.Parse(currentTires[4]), double.Parse(currentTires[5])),
                 new Tire  (int.Parse(currentTires[6]), double.Parse(currentTires[7])),
                };

                //Tire[] tires = new Tire[]
                //{
                //new Tire (int.Parse(currentTires[0]), double.Parse(currentTires[1])),
                //new Tire (123, 32.1),
                //new Tire (123, 3.21),
                //new Tire (123, 321)
                //};
                
                carList.Add(car);
                carInput = Console.ReadLine();
            }


            carList = carList.Where(c => c.Year >= 2017).
                Where(c => c.Engine.HorsePower > 330).
                Where(c => c.Tires.Select(c => c.Pressure).Sum() >= 8 &&
                           c.Tires.Select(c => c.Pressure).Sum() <= 10).ToList();

            foreach (var item in carList)
            {
                item.Drive(20);

                item.WhoAmI(item);

            }
        }
    }
}
