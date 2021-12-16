namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCountriesXmlDto[]), new XmlRootAttribute("Countries"));

            using var stringReader = new StringReader(xmlString);

            var countries = (ImportCountriesXmlDto[])xmlSerializer.Deserialize(stringReader);

            var sb = new StringBuilder();

            foreach (var c in countries)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var country = new Country
                {
                    CountryName = c.CountryName,
                    ArmySize = c.ArmySize
                };

                context.Countries.Add(country);
                sb.AppendLine($"Successfully import {country.CountryName} with {country.ArmySize} army personnel.");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportManufacturersXmlDto[]), new XmlRootAttribute("Manufacturers"));

            using var stringReader = new StringReader(xmlString);

            var manufacturers = (ImportManufacturersXmlDto[])xmlSerializer.Deserialize(stringReader);

            var manufacturersArray = new List<Manufacturer>();
            var sb = new StringBuilder();

            foreach (var m in manufacturers)
            {
                if (!IsValid(m) || manufacturersArray.Any(x => x.ManufacturerName == m.ManufacturerName))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = m.ManufacturerName,
                    Founded = m.Founded
                };

               manufacturersArray.Add(manufacturer);

                var splitCity = m.Founded.Split(", ");
                var city = splitCity[splitCity.Count() - 2];

                var splitCountry = m.Founded.Split(", ");
                var country = splitCountry[splitCountry.Count() - 1];

                sb.AppendLine($"Successfully import manufacturer {m.ManufacturerName} founded in {city}, {country}.");
            }

            context.Manufacturers.AddRange(manufacturersArray);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {

            var xmlSerializer = new XmlSerializer(typeof(ImportShellsXmlDto[]), new XmlRootAttribute("Shells"));

            using var stringReader = new StringReader(xmlString);

            var shells = (ImportShellsXmlDto[])xmlSerializer.Deserialize(stringReader);

            var sb = new StringBuilder();

            foreach (var s in shells)
            {
                if (!IsValid(s))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber
                };

                context.Shells.Add(shell);

                sb.AppendLine($"Successfully import shell caliber #{shell.Caliber} weight {shell.ShellWeight} kg.");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {

            var guns = JsonSerializer.Deserialize<List<ImportGunsJsonDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var g in guns)
            {
                if (!IsValid(g))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

                var countryGuns = new List<Country>();

                //foreach (var c in g.Countries)
                //{
                //    countryGuns.Add(context.Countries.First(x => x.Id == c));
                //}

                var gun = new Gun
                {
                    ManufacturerId = g.ManufacturerId,
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    NumberBuild = g.NumberBuild,
                    Range = g.Range,
                    GunType = Enum.Parse<GunType>(g.GunType),
                    ShellId = g.ShellId,
                    CountriesGuns = g.Countries.Select(x => new CountryGun
                    {
                        CountryId = x.Id

                    }).ToList()
                };

                context.Guns.Add(gun);

                sb.AppendLine($"Successfully import gun {gun.GunType} with a total weight of {gun.GunWeight} kg. and barrel length of {gun.BarrelLength} m.");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
