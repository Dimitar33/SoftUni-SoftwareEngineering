using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInput = Console.ReadLine().Split().Select(int.Parse).ToArray(); 
            int[] scarfsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>();
            Queue<int> scarfs = new Queue<int>();

            for (int i = 0; i < hatsInput.Length; i++)
            {
                hats.Push(hatsInput[i]);
            }
            for (int i = 0; i < scarfsInput.Length; i++)
            {
                scarfs.Enqueue(scarfsInput[i]);
            }

            List<int> collection = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    collection.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int temp = hats.Pop() + 1;
                    hats.Push(temp);
                }
                else
                {
                    hats.Pop();
                }
            }
            Console.WriteLine($"The most expensive set is: {collection.Max()}");
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
