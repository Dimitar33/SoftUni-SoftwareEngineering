using System;
using System.Collections.Generic;
using System.Linq;

namespace _29_February_2020_Group_2__Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split();
            int position = 0;

            while (cmd[0] != "Love!")
            {
                int jump = int.Parse(cmd[1]);
                position += jump;
                if (position >= houses.Count)
                {
                    position = 0;
                }
                houses[position] -= 2;

                if (houses[position] < 0)
                {
                    houses[position] = 0;
                    Console.WriteLine($"Place {position} already had Valentine's day.");
                }
                else if (houses[position] == 0)
                {
                    Console.WriteLine($"Place {position} has Valentine's day.");
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {position}.");
            if (houses.Exists(c => c != 0))
            {
                int failed = houses.Count(c => c != 0);
                Console.WriteLine($"Cupid has failed {failed} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
