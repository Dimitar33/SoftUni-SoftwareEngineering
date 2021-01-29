using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;

        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<string>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                name = value;
            }

        }

        public int Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                money = value;
            }
        }
        public List<string> Bag { get; set; }
    }
}
