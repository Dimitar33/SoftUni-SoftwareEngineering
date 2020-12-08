using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();
            List<int> extraNums = new List<int>();
            
           
            if (nums2.Count > nums1.Count)
            {
                extraNums.Add(nums2[0]);
                nums2.RemoveAt(0);
                extraNums.Add(nums2[0]);
                nums2.RemoveAt(0);
            }
            else
            {
                extraNums.Add(nums1[nums1.Count - 1]);
                nums1.RemoveAt(nums1.Count - 1);
                extraNums.Add(nums1[nums1.Count - 1]);
                nums1.RemoveAt(nums1.Count - 1);
            }

            for (int i = 0; i < nums2.Count; i++)
            {
                result.Add(nums1[i]);
                result.Add(nums2[nums2.Count - 1 - i]);
            }

            List<int> sorted = new List<int>();

            foreach (var i in result)
            {
                if (i > Math.Min(extraNums[0], extraNums[1]) && i < Math.Max(extraNums[0], extraNums[1]))
                {
                    sorted.Add(i);
                }
            }
            
            sorted.Sort();
            Console.WriteLine(string.Join(" " , sorted));

        }
    }
}
