using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string text = Console.ReadLine();

            string word = "";
            

            for (int i = 0; i < nums.Count; i++)
            {
                int sum = 0;
                
                while (nums[i] > 0)
                {
                    sum  += nums[i] % 10;
                    nums[i] /= 10;
                }
                if (sum > text.Length)
                {
                    sum %= text.Length ;
                }
                word += text[sum];

               text = text.Remove(sum, 1);
               
            }
            Console.WriteLine(word);
        }
    }
}
