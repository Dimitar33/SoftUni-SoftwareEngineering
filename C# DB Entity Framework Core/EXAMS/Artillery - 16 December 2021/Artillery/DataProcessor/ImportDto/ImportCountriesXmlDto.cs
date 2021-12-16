using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesXmlDto
    {
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [Range(50_000, 10_000_000)]
        public int ArmySize { get; set; }
    }
}
