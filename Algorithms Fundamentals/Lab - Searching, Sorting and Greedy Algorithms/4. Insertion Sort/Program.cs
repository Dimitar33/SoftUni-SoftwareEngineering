using System;
using System.Linq;

namespace _4._Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", InsertionSort(nums)));
        }

        private static int[] InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int j = i;

                while (j > 0 && nums[j - 1] > nums[j])
                {
                    Swap(nums, j - 1, j);
                    j--;
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
