using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

            int n = int.Parse(Console.ReadLine());

            nums = nums.Where(c => c % n != 0).ToArray();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
