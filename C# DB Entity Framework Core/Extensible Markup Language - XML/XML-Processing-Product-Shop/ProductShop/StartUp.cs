using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string usersXML = File.ReadAllText("../../../Datasets/users.xml");
            string productsXML = File.ReadAllText("../../../Datasets/products.xml");
            string categoriesXML = File.ReadAllText("../../../Datasets/categories.xml");
            string categoriesProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");

            //System.Console.WriteLine(ImportUsers(context, usersXML));
            //System.Console.WriteLine(ImportProducts(context, productsXML));
            //System.Console.WriteLine(ImportCategories(context, categoriesXML));
            //System.Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXML));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 01. Import Users

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            // 1 iniciate serializer

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUsersDto[]), new XmlRootAttribute("Users"));

            // 2 deserialize xml to dto object

            var usersDto = serializer.Deserialize(new StringReader(inputXml)) as ImportUsersDto[];

            // 3 turn dto object to curent object

            var users = usersDto.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            }).ToList();

            // 4 insert into database

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";

        }

        // 02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductsDto[]), new XmlRootAttribute("Products"));

            var productsDto = serializer.Deserialize(new StringReader(inputXml)) as ImportProductsDto[];

            var products = productsDto.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            }).ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        // 03. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoriesDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = serializer.Deserialize(new StringReader(inputXml)) as ImportCategoriesDto[];

            var categories = categoriesDto.Select(x => new Category
            {
                Name = x.Name
            })
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // 04. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCategoriesProductsDto[]),
                new XmlRootAttribute("CategoryProducts"));

            var categoryIds = context.Categories.Select(x => x.Id);
            var productIds = context.Products.Select(x => x.Id);

            var catProdDto = serializer.Deserialize(new StringReader(inputXml)) as ImportCategoriesProductsDto[];

            var catProds = catProdDto.Select(x => new CategoryProduct
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId
            })
            .Where(x => productIds.Contains(x.ProductId) &&
                        categoryIds.Contains(x.CategoryId))
            .ToList();

            context.CategoryProducts.AddRange(catProds);
            context.SaveChanges();

            return $"Successfully imported {catProds.Count}";
        }

        // 05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductsInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var writer = new StringWriter();

            serializer.Serialize(writer, products, ns);

            return writer.ToString();
        }

        // 06. Export Sold Products

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new UsersWithSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = new MapingDto
                    {
                        prducts = x.ProductsSold.Select(p => new SoldProductsDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()
                    }
                }).ToArray();

            var serializer = new XmlSerializer(typeof(UsersWithSoldProductsDto[]),
                             new XmlRootAttribute("Users"));

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, users, ns);

            return writer.ToString();
        }

        // 07. Export Categories By Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoriesByProductsCount
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(s => s.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(s => s.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesByProductsCount[]), new XmlRootAttribute("Categories"));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var writer = new StringWriter();

            serializer.Serialize(writer, categories, ns);

            return writer.ToString();
        }

        // 08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = new UsersCountDto
            {
                UserCount = context.Users.Count(x => x.ProductsSold.Count > 0),
                Users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Take(10)
                .Select(x => new UsersAndProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,

                    soldProducts =  new SoldProductsCountDto
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(ps => new SoldProductsDto
                        {
                            Name = ps.Name,
                            Price = ps.Price

                        }).OrderByDescending(p => p.Price).ToArray()
                    }
                }).ToArray()
            };



            XmlSerializer serializer = new XmlSerializer(typeof(UsersCountDto), new XmlRootAttribute("Users"));

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, users, ns);

            return writer.ToString();
        }
    }
}