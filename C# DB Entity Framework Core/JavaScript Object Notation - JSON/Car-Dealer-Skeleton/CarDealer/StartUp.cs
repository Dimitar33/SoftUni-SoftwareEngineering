using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string inputJsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            string inputtJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            string inputJsonCars = File.ReadAllText("../../../Datasets/cars.json");
            string inputJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            string inputJsonSales = File.ReadAllText("../../../Datasets/sales.json");

            //ImportSuppliers(context, inputJsonSuppliers);
            //ImportParts(context, inputtJsonParts);
            //ImportCars(context, inputJsonCars);
            //ImportCustomers(context, inputJsonCustomers);
            //ImportSales(context, inputJsonSales);

            Console.WriteLine(GetLocalSuppliers(context));

        }

        private static void InicializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        // 09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
           // InicializeAutoMapper();

            var suppliers =
                JsonConvert.DeserializeObject<IEnumerable<Supplier>>(inputJson);

           // var suppliers = Mapper.Map<IEnumerable<Supplier>>(dtoSupliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        // 10. Import Parts

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
           // InicializeAutoMapper();

            var suplyers = context.Suppliers.Select(x => x.Id).ToArray();

            var parts =
                JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(x => suplyers.Contains(x.SupplierId));

           // var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";

        }

        // 11. Import Cars

        public static string ImportCars(CarDealerContext context, string inputJson)
        {


            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarsInputModel>>(inputJson);

            List<Car> carsList = new List<Car>();

            foreach (var car in dtoCars)
            {
                var currentCar = new Car()
                {
                    Make = car.make,
                    Model = car.model,
                    TravelledDistance = car.travelledDistance
                };
                foreach (var part in car.partsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar { PartId = part});
                }
                carsList.Add(currentCar);
            }

            context.Cars.AddRange(carsList);
            context.SaveChanges();

            return $"Successfully imported {carsList.Count}.";
        }

        // 12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
           // InicializeAutoMapper();

            var customers =
                JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

           // var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // 13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
           // InicializeAutoMapper();

            var sales = 
                JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

           // var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // 14. Export Ordered Customers

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate =  x.BirthDate.ToString("dd/MM/yyyy"),
                    x.IsYoungDriver
                })
                
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonResult;
        }

        // 15. Export Cars From Make Toyota

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(cars, Formatting.Indented);


            return jsonResult;
        }

        // 16. Export Local Suppliers

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suplyers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(suplyers, Formatting.Indented);

            return jsonResult;
        }
    }
}