﻿using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < 3; i++)
            {
                int n = int.Parse(Console.ReadLine());
               

                list.AddFirst(n);
                list.AddLast(n);

            }

            var asd = list.ToArray();

            list.ForEach(c => Console.WriteLine(c));

           
        }
    }
}
