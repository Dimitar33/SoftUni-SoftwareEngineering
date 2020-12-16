using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            string[] cmd = Console.ReadLine().ToLower().Split();

            while (cmd[0] != "end")
            {
                if (cmd[0] == "add")
                {
                    stack.Push(int.Parse(cmd[1]));
                    stack.Push(int.Parse(cmd[2]));
                }
                else if (int.Parse(cmd[1]) <= stack.Count)
                {
                    for (int i = 0; i < int.Parse(cmd[1]); i++)
                    {
                        stack.Pop();
                    }
                }
                cmd = Console.ReadLine().ToLower().Split(); 
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
