using System;

namespace _3._Generating_0_slash_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int idx = int.Parse(Console.ReadLine());

            Vector(new int[idx], 0);
        }

        private static void Vector(int[] arr, int idx)
        {

            if (idx > arr.Length - 1)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                Vector(arr, idx + 1);
            }
        }
    }
}
