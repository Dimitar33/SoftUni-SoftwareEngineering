using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Product
    {
        private string name;

        private int price;

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name 
        { 
            get => name;
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                name = value;
            }

        }
        public int Price
        {
            get => price;
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                price = value;
            }
        }
    }
}
