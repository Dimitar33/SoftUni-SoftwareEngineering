using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> list = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            list = list.Where(c =>
            {
                int num = 0;
                bool flag = false;

                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] % i != 0)
                        {
                            flag = true;
                            break;
                        }

                    }
                }

                return
            })
        }
    }
}
