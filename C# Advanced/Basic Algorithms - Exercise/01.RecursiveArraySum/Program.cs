using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(Recursion(nums, 0));
        }

        public static int Recursion(int[] nums, int index)
        {

            if (index == nums.Length)
            {
                return 0;
            }

            int current = 0;

            current = nums[index] + Recursion(nums, index + 1);

            return current;
        }
    }
}
