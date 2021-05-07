using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            var contex = new ProductShopContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            string inputJsonCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            //var result = ImportUsers(contex, inputJsonUsers);
            //var result1 = ImportProducts(contex, inputJsonProducts);
            //var result2 = ImportCategories(contex, inputJsonCategories);
            //var result3 = ImportCategoryProducts(contex, inputJsonCategoryProducts);

            var result = GetCategoriesByProductsCount(contex);

            Console.WriteLine(result);
        }

        private static void InicialiseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(x => { x.AddProfile<ProductShopProfile>(); });

            IMapper mapper = config.CreateMapper();
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            //InicialiseMapper();

            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(inputJson);

            //var users = Mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // 02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InicialiseMapper();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);

            // var products = Mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";

        }

        // 03. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InicialiseMapper();

            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson)
                .Where(x => x.Name != null);

            // var categories = Mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // 04. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            // File.WriteAllText("../../../productsInRange.json", json);

            return json;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(c => c.BuyerId != null) &&
                            x.ProductsSold.Count > 0)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToArray();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(c => c.Product.Price).ToString("F2")
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }
    }
}