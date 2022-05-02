using System;
using System.Linq;

namespace _5._Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", QuickSort(nums, 0 , nums.Length - 1)));
        }

        private static int[] QuickSort(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return nums;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                 if (nums[left] > nums[pivot] && nums[right] < nums[pivot])
                {
                    Swap(nums, left, right);
                }

                if (nums[left] <= nums[pivot])
                {
                    left++;
                }

                if (nums[right] >= nums[pivot])
                {
                    right--;
                }
            }

            Swap(nums, pivot, right);

            QuickSort(nums, start, right - 1);
            QuickSort(nums, right + 1, end);

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
