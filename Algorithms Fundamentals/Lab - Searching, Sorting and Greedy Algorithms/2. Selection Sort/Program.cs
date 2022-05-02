using System;
using System.Linq;

namespace _2._Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", MergeSort(nums)));
        }

        private static int[] MergeSort(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int smallest = nums[i];
                int smallestIdx = i;

                for (int j = i; j < nums.Length; j++)
                {
                    if (smallest > nums[j])
                    {
                        smallest = nums[j];
                        smallestIdx = j;
                    }
                }
                Swap(nums, i, smallestIdx);
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
