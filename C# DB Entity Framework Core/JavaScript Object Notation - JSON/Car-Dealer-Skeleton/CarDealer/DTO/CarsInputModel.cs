using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarsInputModel
    {
        public string make { get; set; }
        public string model { get; set; }
        public long travelledDistance { get; set; }
        public int[] partsId { get; set; }
    }
}
