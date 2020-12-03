using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;
            int odSum = 0;

            for (int i = 0; i < num.Length; i++)
            {

                if (num[i] % 2 == 0)
                {
                    evenSum += num[i];
                }
                else
                {
                    odSum += num[i];
                }
            }

            Console.WriteLine(evenSum - odSum);
        }
    }
}
