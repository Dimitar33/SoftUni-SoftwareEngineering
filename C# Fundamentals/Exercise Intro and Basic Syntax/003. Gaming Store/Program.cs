using System;

namespace _003._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double price = 0;
            double startMoney = budget;

            while (game != "Game Time")
            {
                if (game == "OutFall 4")
                {
                    price = 39.99;
                }
                else if (game == "CS: OG")
                {
                    price = 15.99;
                }
                else if (game == "Zplinter Zell")
                {
                    price = 19.99;
                }
                else if (game == "Honored 2")
                {
                    price = 59.99;
                }
                else if (game == "RoverWatch")
                {
                    price = 29.99;
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    game = Console.ReadLine();
                    continue;
                }
                if (budget >= price)
                {
                    budget -= price;
                    Console.WriteLine($"Bought {game}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    Environment.Exit(0);
                }
                game = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${startMoney - budget:f2}. Remaining: ${budget:f2}");
        }
    }
}
