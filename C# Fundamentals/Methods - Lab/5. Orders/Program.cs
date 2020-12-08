using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            bill(item, count);
        }

        private static void bill(string item, int count)
        {
            double price = 0;

            switch (item)
            {
                case "coffee":
                    price = 1.5;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.4;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }
            double total = price * count;

            Console.WriteLine($"{total:f2}");
        }
    }
}
