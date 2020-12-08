using System;
using System.Linq;

namespace _1._5_July_2020_Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] end = Console.ReadLine().Split();

            int swap1 = 0;
            int swap2 = 0;

            while (end[0] != "end")
            {
                
                if (end[0] == "swap")
                {
                    swap1 = int.Parse(end[1]);
                    swap2 = int.Parse(end[2]);

                    var temp = nums[swap1];
                    nums[swap1] = nums[swap2];
                    nums[swap2] = temp;
                }
                else if (end[0] == "multiply")
                {
                    swap1 = int.Parse(end[1]);
                    swap2 = int.Parse(end[2]);

                    nums[swap1] *= nums[swap2];
                }
                else if (end[0] == "decrease")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] -= 1;
                    }
                }
                end = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join (", " , nums));
        }
    }
}
