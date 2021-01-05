using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = range[0];
            int end = range[1];

            List<int> nums = new List<int>();

            string cmd = Console.ReadLine();

         
            for (int i = start; i <= end; i++)
            {
                nums.Add(i);
            }
            Console.WriteLine(string.Join(" ", nums.Where(cmd == "odd" ?
             new Func<int, bool>( c => c % 2 != 0) :  c => c % 2 == 0 )));
        }
    }
}
