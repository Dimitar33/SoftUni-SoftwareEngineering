using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("CategoryProduct")]
    public class MapingDto
    {
        [XmlElement("Product")]
        public SoldProductsDto[] prducts { get; set; }
    }
}
