using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> que = new Queue<int>(nums);

           

            Console.WriteLine(string.Join(", ", que.Where(c => c % 2 == 0)));
        }
    }
}
