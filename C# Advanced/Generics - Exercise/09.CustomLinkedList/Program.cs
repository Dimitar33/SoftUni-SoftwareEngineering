using System;
using System.Collections;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
           
            list.Add(2);
            list.Add(0);
            list.Add(5);
            list.Add(3);
            list.Add(9);
            list.Insert(3, 12);

            Console.WriteLine(list[6]);

            list.Swap(2, 4);

            Console.WriteLine(list.Contains(2));
            Console.WriteLine(list.Contains(0));
            list.Contains(0);


            list.RemoveAt(1);
            list.RemoveAt(3);






        }
    }
}
