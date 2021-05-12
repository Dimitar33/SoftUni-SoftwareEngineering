using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class CarPartIdsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
