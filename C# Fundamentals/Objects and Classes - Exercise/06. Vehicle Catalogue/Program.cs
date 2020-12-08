using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            List<Vehicle> catalog = new List<Vehicle>();

            while (data[0] != "End")
            {
                Vehicle vehicle = new Vehicle(data[0], data[1], data[2],int.Parse(data[3]));

                catalog.Add(vehicle);

                data = Console.ReadLine().Split();
            }
            string reader = Console.ReadLine();

            while (reader != "Close the Catalogue")
            {
                Vehicle print = catalog.First(c => c.Brand == reader);
                

                Console.WriteLine(print);
               

                reader = Console.ReadLine();
            }
            List<Vehicle> cars = catalog.Where(c => c.Type == "car").ToList();
            List<Vehicle> trucks = catalog.Where(c => c.Type == "truck").ToList();

            double truckPower = trucks.Sum(c => c.HPower);
            double carPower = cars.Sum(c => c.HPower);

            double TP = 0;
            double CP = 0;

            

            if (trucks.Count  > 0)
            {
                TP = truckPower / trucks.Count;
            }
            if (cars.Count > 0)
            {
                CP = carPower / cars.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {CP:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {TP:F2}.");
        }

        class Vehicle
        {   
            public Vehicle(string type, string brand, string colour , double hPower)
            {
                Type = type;
                Brand = brand;
                Colour = colour;
                HPower = hPower;
            }
            
            public string Type { get; set; }
            public string Brand { get; set; }
            public string Colour { get; set; }
            public double HPower { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Type: {(Type  == "car" ? "Car" : "Truck")}");
                sb.AppendLine($"Model: {Brand}");
                sb.AppendLine($"Color: {Colour}");
                sb.AppendLine($"Horsepower: {HPower}");

                return sb.ToString().TrimEnd();
            }
        }
       
    }
}
