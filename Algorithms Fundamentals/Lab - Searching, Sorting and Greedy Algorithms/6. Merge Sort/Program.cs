using System;
using System.Linq;

namespace _6._Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", MergeSort(nums)));
        }

        private static int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums;
            }

            int[] left = nums.Take(nums.Length / 2).ToArray();
            int[] right = nums.Skip(nums.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));

        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int leftIdx = 0;
            int rightIdx = 0;
            int idx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {

                if (left[leftIdx] < right[rightIdx])
                {
                    merged[idx++] = left[leftIdx++];
                }
                else
                {
                    merged[idx++] = right[rightIdx++];
                }
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[idx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[idx++] = right[i];
            }

            return merged;
        }
    }
}
