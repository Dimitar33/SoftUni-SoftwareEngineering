using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();

            List<Product> products = new List<Product>();

            while (info[0] != "buy")
            {
                
                if (products.Any(c => c.Name == info[0]))
                {
                    products.First(c => c.Name == info[0]).Price = double.Parse(info[1]);
                    products.First(c => c.Name == info[0]).Quantity += int.Parse(info[2]);
                    
                }
                else
                {
                    Product product = new Product();

                    product.Name = info[0];
                    product.Price = double.Parse(info[1]);
                    product.Quantity = int.Parse(info[2]);

                    products.Add(product);
                }


                info = Console.ReadLine().Split();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} -> {(item.Price * item.Quantity):f2}");
            }
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
