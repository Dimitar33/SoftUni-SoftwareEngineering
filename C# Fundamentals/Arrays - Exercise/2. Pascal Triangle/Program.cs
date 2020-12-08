using System;

namespace _2._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[1];

            for (int i = 0; i < n; i++)
            {
                arr[0] = 1;
                arr[arr.Length - 1] = 1;
                int[] arr2 = new int[i + 1];
                arr2[0] = 1;
                arr2[arr2.Length - 1] = 1;

                for (int j = 1; j < i; j++)
                {

                    arr2[j] = arr[j] + arr[j - 1];

                }
                arr = arr2;


                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
