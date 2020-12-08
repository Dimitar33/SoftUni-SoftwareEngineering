using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" -> ");

            var companies = new SortedDictionary<string, List<string>>();

            while (data[0] != "End")
            {
                if (!companies.ContainsKey(data[0]))
                {
                    companies.Add(data[0], new List<string>());
                    companies[data[0]].Add(data[1]);
                }
                else
                {
                    if (!companies[data[0]].Contains(data[1]))
                    {
                        companies[data[0]].Add(data[1]);
                    }
                }
                data = Console.ReadLine().Split(" -> ");
            }

            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);

                foreach (var i in item.Value)
                {
                    Console.WriteLine($"-- {i}");
                }
            }
        }
    }
}
