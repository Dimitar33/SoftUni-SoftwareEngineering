using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> min = c =>
            {
                int min = int.MaxValue;
                foreach (var item in c)
                {
                    if (min > item)
                    {
                        min = item;
                    }

                }
                return min;

            };

            Console.WriteLine(min(nums));
        }
        
    }
}
