using System;

namespace _3._10_March_2019_Group_1._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double pplCount = double.Parse(Console.ReadLine());
            double fuelPrice = double.Parse(Console.ReadLine());
            double foodPerPPerDay = double.Parse(Console.ReadLine());
            double roomPerPPerDay = double.Parse(Console.ReadLine());

            double food = foodPerPPerDay * pplCount * days;
            double room = roomPerPPerDay * pplCount * days;

            if (pplCount > 10)
            {
                room *= 0.75;
            }
            double expenses = food + room;

            for (int i = 1; i <= days; i++)
            {
                double distance = double.Parse(Console.ReadLine());

                expenses += distance * fuelPrice;

                
                if (i % 3 == 0 || i % 5 == 0)
                {
                    expenses *= 1.4;
                }
                if (expenses > budget)
                {
                    expenses -= budget;
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses:f2}$ more.");
                    Environment.Exit(0);
                }
                if (i % 7 == 0)
                {
                    expenses -= expenses / pplCount;
                }
            }
            budget -= expenses;
            Console.WriteLine($"You have reached the destination. You have {budget:f2}$ budget left.");
        }
    }
}
