using System;
using System.Linq;

namespace _4._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] firstPart = n.Take(n.Length / 2).ToArray();
            int[] secondPart = n.Skip(n.Length / 2).ToArray();
            int[] sum = new int[firstPart.Length];

            int[] firstReverce = firstPart.Take(firstPart.Length / 2).Reverse().ToArray();
            int[] second = firstPart.Skip(firstPart.Length / 2).ToArray();
            int[] third = secondPart.Take(secondPart.Length / 2).ToArray();
            int[] fourthReverce = secondPart.Skip(secondPart.Length / 2).Reverse().ToArray();
            int count = 0;

            for (int i = 0; i < firstReverce.Length; i++)
            {
                sum[count] = firstReverce[i] + second[i];
                count++; 
            }

            for (int i = 0; i < firstReverce.Length; i++)
            {
                sum[count] = third[i] + fourthReverce[i];
                count++;
            }



            Console.WriteLine(string.Join (" " , sum));
           
        }
    }
}
