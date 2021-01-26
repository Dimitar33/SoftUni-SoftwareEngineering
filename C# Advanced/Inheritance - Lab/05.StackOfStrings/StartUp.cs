using System;
using System.Collections.Generic;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            stack.Push("asd");

            List<string> list = new List<string>();

            list.Add("asd");
            list.Add("afds");
            list.Add("gfdd");
            list.Add("fdwe");

            stack.AddRange( list);
            Console.WriteLine(stack.IsEmpty());

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());

            }

            Console.WriteLine(stack.IsEmpty());

        }
    }
}
