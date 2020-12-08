using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> newList = new List<int>();

            int diff = Math.Abs(nums1.Count - nums2.Count);
            int minCount = Math.Min(nums1.Count, nums2.Count);
            int maxCount = diff + minCount;

            for (int i = 0; i < minCount; i++)
            {
                newList.Add(nums1[i]);
                newList.Add(nums2[i]);
            }

            for (int i = minCount; i < maxCount; i++)
            {
                if (nums1.Count > nums2.Count)
                {
                    newList.Add(nums1[i]);
                }
                else
                {
                    newList.Add(nums2[i]);
                }
            }


            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
