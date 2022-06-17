using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Models.ViewModels
{
    public class CustomerSearchViewModel
    {

        public int CustomerID { get; set; }
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string SalesTerritoryName { get; set; }
    }
}