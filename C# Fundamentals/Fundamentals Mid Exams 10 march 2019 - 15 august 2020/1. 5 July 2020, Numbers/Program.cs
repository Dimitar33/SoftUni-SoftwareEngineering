using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._5_July_2020__Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double average = nums.Average();

            List<int> bigerNums = nums.Where(c => c > average).ToList();

            bigerNums = bigerNums.OrderByDescending(c => c).ToList();

            if (bigerNums.Count > 5)
            {
                bigerNums.RemoveRange(5, (bigerNums.Count) - 5);
            }
            if (bigerNums.Count < 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", bigerNums));

            }

        }
    }
}
