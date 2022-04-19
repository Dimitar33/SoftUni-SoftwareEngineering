using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(nums, 0));
        }

        private static int GetSum(int[] nums, int idx)
        {
            if (idx == nums.Length - 1)
            {
                return nums[idx];
            }

            return nums[idx] + GetSum(nums, idx + 1);
        }
    }
}
