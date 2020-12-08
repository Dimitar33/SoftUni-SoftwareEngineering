using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> dic = new SortedDictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                }
                else
                {
                    dic.Add(nums[i], 1);
                }

            }
            
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
