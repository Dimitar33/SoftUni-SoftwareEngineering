using System;
using System.Collections;

namespace Create_Custom_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomList list = new CustomList();

            //list.Add(2);
            //list.Add(0);
            //list.Add(5);
            //list.Add(3);
            //list.Add(9);
            //list.Insert(3, 12);

            //Console.WriteLine(list[6]);

            //list.Swap(2, 4);

            //Console.WriteLine(list.Contains(2));
            //Console.WriteLine(list.Contains(0));
            //list.Contains(0);


            //list.RemoveAt(1);
            //list.RemoveAt(3);

            CustomStack stack = new CustomStack();
            

            stack.Push(4);
            stack.Push(7);
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            stack.Push(2);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

        }
    }
}
