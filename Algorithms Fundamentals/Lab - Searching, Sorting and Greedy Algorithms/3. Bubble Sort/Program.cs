using System;
using System.Diagnostics;
using System.Linq;

namespace _3._Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            var nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", BubleSort(nums)));
        }

        private static int[] BubleSort(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[j - 1] > nums[j])
                    {
                        Swap(nums, j - 1, j);
                    }
                }
            }

            return nums;
        }

        private static void Swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
    }
}
