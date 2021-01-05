using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);

            int[] nums =num.Split(", ").Select(parser).ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
