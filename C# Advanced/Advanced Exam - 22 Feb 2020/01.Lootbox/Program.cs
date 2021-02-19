using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            Stack<int> stask = new Stack<int>();

            for (int i = 0; i < firstBoxInput.Length; i++)
            {
                queue.Enqueue(firstBoxInput[i]);
            }

            for (int i = 0; i < secondBoxInput.Length; i++)
            {
                stask.Push(secondBoxInput[i]);
            }

            int sum = 0;

            while (stask.Count > 0 && queue.Count > 0)
            {
                int firstBoxItem = queue.Peek();
                int lastBoxItem = stask.Pop();

                if ((firstBoxItem + lastBoxItem) % 2 == 0)
                {
                    sum += firstBoxItem + lastBoxItem;
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(lastBoxItem);
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
        }
    }
}
