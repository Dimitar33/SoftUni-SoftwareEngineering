using System;
using System.Linq;

namespace _1._Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int wantedNum = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(nums, wantedNum));
        }

        private static int BinarySearch(int[] arr, int n)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                int middle = (right + left) / 2;

                if (arr[middle] == n)
                {
                    return middle;
                }

                if (n > arr[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
