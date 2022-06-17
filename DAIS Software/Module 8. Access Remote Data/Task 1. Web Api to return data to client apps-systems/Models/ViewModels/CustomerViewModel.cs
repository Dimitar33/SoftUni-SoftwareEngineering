using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public int? StoreID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}