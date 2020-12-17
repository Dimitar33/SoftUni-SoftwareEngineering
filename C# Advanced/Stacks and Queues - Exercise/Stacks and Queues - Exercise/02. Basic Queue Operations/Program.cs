using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> que = new Queue<int>(nums);

            for (int i = 0; i < input[1]; i++)
            {
                que.Dequeue();
            }
            if (que.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (que.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(que.Min());
            }
        }
    }
}
