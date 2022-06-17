﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Models.ViewModels
{
    public class ProductViewModel
    {

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public bool MakeFlag { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        public string Color { get; set; }

        public short SafetyStockLevel { get; set; }

        public short ReorderPoint { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Size { get; set; }

        public string SizeUnitMeasureCode { get; set; }

        public string WeightUnitMeasureCode { get; set; }

        public decimal? Weight { get; set; }

        public int DaysToManufacture { get; set; }

        public string ProductLine { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public DateTime SellStartDate { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}