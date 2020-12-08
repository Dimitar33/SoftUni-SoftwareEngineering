using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n.Length; i++)
            {

                bool isTrue = false;
                for (int j = i + 1; j < n.Length; j++)
                {
                    if (n[i] <= n[j])
                    {
                        isTrue = true;
                        break;
                    }

                }

                if (isTrue)
                {
                    continue;
                }
                Console.Write(n[i] + " ");

            }
           
        }
    }
}
