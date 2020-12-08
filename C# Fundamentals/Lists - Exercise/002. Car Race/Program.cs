using System;
using System.Collections.Generic;
using System.Linq;

namespace _002._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            double sumLeft = 0;
            double sumRight = 0;

            for (int i = 0; i < nums.Count / 2; i++)
            {
                if (nums[i] == 0)
                {
                    double bonus = sumLeft * 0.2;
                    sumLeft -= bonus;
                }
                else
                {

                    sumLeft += nums[i];
                }

            }
            for (int i = nums.Count - 1; i > nums.Count / 2; i--)
            {

                if (nums[i] == 0)
                {
                    double bonus = sumRight * 0.2;
                    sumRight -= bonus;
                }
                else
                {
                    sumRight += nums[i];
                }
            }

            if (sumLeft < sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
        }
    }
}
