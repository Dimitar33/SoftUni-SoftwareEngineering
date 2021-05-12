using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string inputParts = File.ReadAllText("../../../Datasets/parts.xml");
            string inputCars = File.ReadAllText("../../../Datasets/cars.xml");
            string inputCustomers = File.ReadAllText("../../../Datasets/customers.xml");
            string inputSales = File.ReadAllText("../../../Datasets/sales.xml");

            Console.WriteLine(ImportSuppliers(context, inputSuppliers));
            Console.WriteLine(ImportParts(context, inputParts));
            Console.WriteLine(ImportCars(context, inputCars));
            Console.WriteLine(ImportCustomers(context, inputCustomers));
            Console.WriteLine(ImportSales(context, inputSales));
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            var supplyersDto = serializer.Deserialize(new StringReader(inputXml)) as ImportSuppliersDto[];

            var supplyers = supplyersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter

            }).ToList();

            context.Suppliers.AddRange(supplyers);
            context.SaveChanges();

            return $"Successfully imported {supplyers.Count}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));

            var suplyersIds = context.Suppliers.Select(x => x.Id);

            var partsDto = serializer.Deserialize(new StringReader(inputXml)) as ImportPartsDto[];

            var parts = partsDto
                .Where(x => suplyersIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                }).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));

            var parts = context.Parts.Select(x => x.Id).ToList();

            var carsDto = serializer.Deserialize(new StringReader(inputXml)) as ImportCarsDto[];

            var cars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,

                    PartCars = x.CarParts
                    .Select(x => x.Id)
                    .Distinct()
                    .Intersect(parts)
                    .Select(x => new PartCar
                    {
                        PartId = x

                    }).ToList()

                }).ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        // 12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));

            var customersDto = serializer.Deserialize(new StringReader(inputXml)) as ImportCustomersDto[];

            var customers = customersDto.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver

            }).ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // 13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var salesDto = serializer.Deserialize(new StringReader(inputXml)) as ImportSalesDto[];

            var cars = context.Cars.Select(x => x.Id);

            var sales = salesDto.Where(x => cars.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount

                }).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";

        }
    }
}