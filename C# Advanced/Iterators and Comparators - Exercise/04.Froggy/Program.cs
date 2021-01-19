using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Lake stones = new Lake(nums);

            Console.WriteLine(string.Join (", ", stones));
        }
    }
}
