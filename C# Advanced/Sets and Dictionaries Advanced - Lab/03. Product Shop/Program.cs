using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(", ");          

            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (data[0] != "Revision")
            {
                if (!shops.ContainsKey(data[0]))
                {
                    shops.Add(data[0], new Dictionary<string, double>());
                    shops[data[0]].Add(data[1], double.Parse(data[2]));
                }
                else
                {
                    shops[data[0]].Add(data[1], double.Parse(data[2]));
                }

                data = Console.ReadLine().Split(", ");
            }

            foreach (var item in shops.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
