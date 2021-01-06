using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split().Distinct().Select(int.Parse).ToArray();

            List<int> list = new List<int>();


            for (int i = 1; i <= n; i++)
            {
                bool isDevisible = true;

                foreach (var item in nums)
                {
                    Predicate<int> predicate = c => i % c != 0;

                    if (predicate(item))
                    {
                        isDevisible = false;
                        break;
                    }

                }
                if (isDevisible)
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
