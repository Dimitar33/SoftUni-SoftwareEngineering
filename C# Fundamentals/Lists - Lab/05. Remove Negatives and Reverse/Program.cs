using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = nums.Where(c => c >= 0).Reverse().ToList();

            if (result.Count <= 0)
            {
                Console.WriteLine("empty");
            }
            else
            {

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
