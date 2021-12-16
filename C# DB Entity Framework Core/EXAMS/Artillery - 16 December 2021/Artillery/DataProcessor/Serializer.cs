
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var result = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .ToList()
                .Select(x => new ExportShellsJsonDto
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                    .Where(x => x.GunType == GunType.AntiAircraftGun)
                    .Select(x => new ExportGundsJsonDto
                    {
                        BarrelLength = x.BarrelLength,
                        GunType = x.GunType.ToString(),
                        GunWeight = x.GunWeight,
                        Range = x.Range > 3000 ? "Long-range" : "Regular range"

                    })
                    .OrderByDescending(x => x.GunWeight)
                    .ToList()

                }).OrderBy(x => x.ShellWeight);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var result = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .ToList()
                .Select(x => new ExportGunsXmlDto
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    BarrelLength = x.BarrelLength,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                    .Where(x => x.Country.ArmySize > 4500000)
                    .Select(x => new ExportCountriesXmlDto
                    {
                        ArmySize = x.Country.ArmySize,
                        Country = x.Country.CountryName

                    })
                    .OrderBy(x => x.ArmySize)
                    .ToArray()

                })
                .OrderBy(x => x.BarrelLength)
                .ToList();


            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(); 
            namespaces.Add(string.Empty, string.Empty);


            var serializer = 
                new XmlSerializer(typeof(List<ExportGunsXmlDto>), new XmlRootAttribute("Guns"));
            serializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().Trim();
        }
    }
}
