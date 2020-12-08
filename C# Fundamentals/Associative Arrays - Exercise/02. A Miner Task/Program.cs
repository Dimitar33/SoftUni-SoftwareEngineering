using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resourse = Console.ReadLine();

            var dict = new Dictionary<string, int>();

            while (resourse != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(resourse))
                {
                    dict[resourse] += quantity;
                }
                else
                {
                    dict.Add(resourse, quantity);
                }
                resourse = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
