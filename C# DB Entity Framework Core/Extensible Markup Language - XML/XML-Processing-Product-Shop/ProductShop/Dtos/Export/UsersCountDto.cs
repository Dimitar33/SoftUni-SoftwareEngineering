using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersCountDto
    {
        [XmlElement("count")]
        public int UserCount { get; set; }

        [XmlElement("users")]
        public UsersAndProductsDto[] Users { get; set; }
    }
}
