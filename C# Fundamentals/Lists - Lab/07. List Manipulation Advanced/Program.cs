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
            bool isFlag = false;

            while (command[0] != "end")
            {

                if (command[0] == "add")
                {
                    nums.Add(int.Parse(command[1]));
                    isFlag = true;
                }
                else if (command[0] == "remove")
                {
                    nums.RemoveAll(n => n == int.Parse(command[1]));
                    isFlag = true;
                }
                else if (command[0] == "removeat")
                {
                    nums.RemoveAt(int.Parse(command[1]));
                    isFlag = true;
                }
                else if (command[0] == "insert")
                {
                    nums.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isFlag = true;
                }
                else if (command[0] == "contains")
                {
                    Console.WriteLine(nums.Contains(int.Parse(command[1])) ? "Yes" : "No such number");
                }
                else if (command[0] == "printeven")
                {
                    Console.WriteLine(string.Join(" ", nums.Where(c => c % 2 == 0)));
                }
                else if (command[0] == "printodd")
                {
                    Console.WriteLine(string.Join(" ", nums.Where(c => c % 2 != 0)));
                }
                else if (command[0] == "getsum")
                {
                    Console.WriteLine(nums.Sum());
                }
                else if (command[0] == "filter")
                {
                    if (command[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(c => c < int.Parse(command[2]))));
                    }
                    else if (command[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(c => c <= int.Parse(command[2]))));
                    }
                    else if (command[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(c => c > int.Parse(command[2]))));
                    }
                    else if (command[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(c => c >= int.Parse(command[2]))));
                    }



                }

                command = Console.ReadLine().ToLower().Split();
            }

            if (isFlag)
            {

                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
