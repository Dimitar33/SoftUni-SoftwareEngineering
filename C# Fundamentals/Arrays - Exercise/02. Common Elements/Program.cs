using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            foreach (var i in arr2)
            {
                foreach (var j in arr1)
                {
                    if (i == j)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
