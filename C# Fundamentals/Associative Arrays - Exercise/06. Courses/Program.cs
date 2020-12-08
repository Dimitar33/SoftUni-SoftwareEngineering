using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            var register = new Dictionary<string, List<string>>();

            while (data[0] != "end")
            {
                if (register.ContainsKey(data[0]))
                {
                    register[data[0]].Add(data[1]);
                }
                else
                {
                    register.Add(data[0], new List<string>());
                    register[data[0]].Add(data[1]);
                }

                data = Console.ReadLine().Split(" : ");
            }

            register = register.OrderByDescending(c => c.Value.Count).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in register)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var i in item.Value.OrderBy(c => c))
                {
                    Console.WriteLine($"-- {i}");
                }
            }
        }
    }
}
