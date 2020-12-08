using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();

            var dict = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");

                }
            }
        }
    }
}
