using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (cmd[0] == 1)
                {
                    nums.Push(cmd[1]);
                }
                else if (cmd[0] == 2 && nums.Count > 0)
                {
                    nums.Pop();
                }
                else if (cmd[0] == 3 && nums.Count > 0)
                {
                    Console.WriteLine(nums.Max());
                }
                else if (cmd[0] == 4 && nums.Count > 0)
                {
                    Console.WriteLine(nums.Min());
                }
            }
            Console.WriteLine(string.Join(", " , nums));
        }
    }
}
