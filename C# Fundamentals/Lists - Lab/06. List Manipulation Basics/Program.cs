using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else if (command[0] == "remove")
                {
                    nums.RemoveAll(n => n == int.Parse(command[1]));
                }
                else if (command[0] == "removeat")
                {
                    nums.RemoveAt(int.Parse(command[1]));
                }
                else
                {
                    nums.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                command = Console.ReadLine().ToLower().Split();
            }
            Console.WriteLine(string.Join(" " , nums));
        }
    }
}
