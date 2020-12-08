using System;


namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            double sum = 0;

            while (start != "Start")
            {
                double coins = double.Parse(start);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                start = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    if (sum - 2 >= 0)
                    {
                        sum -= 2;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Water")
                {
                    if (sum - 0.7 >= 0)
                    {
                        sum -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Crisps")
                {
                    if (sum - 1.5 >= 0)
                    {
                        sum -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Soda")
                {
                    if (sum - 0.8 >= 0)
                    {
                        sum -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (product == "Coke")
                {
                    if (sum - 1 >= 0)
                    {
                        sum -= 1;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                product = Console.ReadLine();

            }
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}

