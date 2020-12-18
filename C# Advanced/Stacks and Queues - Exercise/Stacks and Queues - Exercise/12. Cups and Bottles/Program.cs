using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);
            int water = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cup = cups.Dequeue();

                while (bottles.Peek() < cup)
                {
                    cup -= bottles.Pop();
                    
                }
                water += bottles.Pop() - cup ;
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {water}");
        }
    }
}
