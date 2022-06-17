using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Task_1.Web_Api_to_return_data_to_client_apps_systems.Models.ViewModels;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers
{
    public class SalesDataController : ApiController
    {
        private readonly AppDbContext data = new AppDbContext();

        [Route("api/SalesData/Customers")]
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return data.Customers.Select(x => new CustomerViewModel
            {
                StoreID = x.StoreID,
                CustomerID = x.CustomerID,
                AccountNumber = x.AccountNumber,
                ModifiedDate = x.ModifiedDate,
                TerritoryID = x.TerritoryID
            });
        }

        [Route("api/SalesData/CustomersInfo/{firstName?}/{midName?}/{lastName?}")]
        public IEnumerable<CustomerSearchViewModel> GetCustomersInfo(
            string firstName = "", string midName = "", string lastName = "")
        {
            return data.Customers.Where(x => x.Person.FirstName.Contains(firstName) && x.Person.LastName.Contains(lastName) &&
              x.Person.MiddleName.Contains(midName))
                .Select(x => new CustomerSearchViewModel
                {
                    SalesTerritoryName = x.SalesTerritory.Name,
                    AccountNumber = x.AccountNumber,
                    CustomerID = x.CustomerID,
                    FirstName = x.Person.FirstName,
                    MidName = x.Person.MiddleName,
                    LastName = x.Person.LastName,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

        }

        //[Route("api/SalesData/ProductsInfo")]
        //public int GetProductsInfo()
        //{
        //    return 
        //}

        [Route("api/SalesData/Products")]
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return data.Products.Select(x => new ProductViewModel
            {
                SafetyStockLevel = x.SafetyStockLevel,
                SellEndDate = x.SellEndDate,
                SellStartDate = x.SellStartDate,
                Size = x.Size,
                SizeUnitMeasureCode = x.SizeUnitMeasureCode,
                StandardCost = x.StandardCost,
                Style = x.Style,
                Class = x.Class, 
                Color = x.Color,   
                DaysToManufacture = x.DaysToManufacture,
                DiscontinuedDate = x.DiscontinuedDate,
                FinishedGoodsFlag = x.FinishedGoodsFlag,
                ListPrice = x.ListPrice,
                MakeFlag = x.MakeFlag,
                Name = x.Name,
                ProductLine = x.ProductLine,
                ProductNumber = x.ProductNumber,
                ReorderPoint = x.ReorderPoint,
                Weight = x.Weight,
                ModifiedDate = x.ModifiedDate
                
            });
        }
    }
}