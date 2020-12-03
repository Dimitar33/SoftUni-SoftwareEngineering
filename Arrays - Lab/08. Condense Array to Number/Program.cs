using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (n.Length > 1)
            {
                int[] num = new int[n.Length - 1];

                for (int i = 0; i < n.Length - 1; i++)
                {


                    num[i] = n[i] + n[i + 1];

                }
                n = num;
            }

            Console.WriteLine(n.Sum());
        }
    }
}
