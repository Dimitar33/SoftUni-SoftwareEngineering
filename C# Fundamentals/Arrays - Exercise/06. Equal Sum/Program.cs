using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum1 = 0;
            int sum2 = 0;
            int element = -1;

            for (int j = 0; j < n.Length; j++)
            {
                element++;
                sum1 = 0;
                sum2 = 0;

                for (int i = element + 1; i < n.Length; i++)
                {
                    sum1 += n[i];
                }
                for (int i = 0; i < element; i++)
                {
                    sum2 += n[i];
                }

                if (sum1 == sum2)
                {
                    break;
                }
            }
            if (element == 0)
            {
                Console.WriteLine("0");
            }
            else if (sum1 == sum2)
            {

                Console.WriteLine(element);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
