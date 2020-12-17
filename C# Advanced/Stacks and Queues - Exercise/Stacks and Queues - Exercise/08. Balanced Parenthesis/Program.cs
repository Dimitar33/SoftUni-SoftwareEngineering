using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            Queue<char> que = new Queue<char>(data);
            Stack<char> stack = new Stack<char>();

            while (que.Count > 0)
            {
                if (que.Peek() == '(' || que.Peek() == '{' || que.Peek() == '[')
                {
                    stack.Push(que.Dequeue());
                }
                else if (stack.Count == 0)
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }

                else if ((stack.Peek() == '(' && que.Peek() == ')') || (stack.Peek() == '{' && que.Peek() == '}') || (stack.Peek() == '[' && que.Peek() == ']') )
                {
                    stack.Pop();
                    que.Dequeue();
                }
                else
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("YES");
        }
    }
}
