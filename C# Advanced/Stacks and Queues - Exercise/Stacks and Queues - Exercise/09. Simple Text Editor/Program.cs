using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                switch (cmd[0])
                {
                    case "1":

                        sb.Append(cmd[1]);
                        stack.Push(sb.ToString());

                        break;
                    case "2":
                        int index = int.Parse(cmd[1]);

                        sb.Remove(sb.Length - index , index );
                        stack.Push(sb.ToString());

                        break;
                    case "3":

                        int indexOf = int.Parse(cmd[1]);
                        Console.WriteLine(sb[indexOf - 1]);

                        break;
                    case "4":
                        
                        stack.Pop();
                        sb = new StringBuilder(stack.Peek());


                        break;
                    default:
                        break;
                }
            }
        }
    }
}
