using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInt
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
          
                list.Add(text);
            }

            Box<int> txt = new Box<int>(list);

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            txt.Swap(nums[0], nums[1]);

            Console.WriteLine(txt);

        }

       
    }
}
