using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();


            Stack<string> stack = new Stack<string>(input);


            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (oper == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else if (oper == "-")
                {
                    stack.Push((first - second).ToString());
                }

            }
            Console.WriteLine(stack.Pop());
        }
    }

}
