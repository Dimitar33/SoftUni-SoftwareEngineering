using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int buletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] buletsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            int count = gunBarrel;
           
            Stack<int> bulets = new Stack<int>(buletsCount);
            Queue<int> locks = new Queue<int>(locksCount);

            while (bulets.Count > 0 && locks.Count > 0)
            {
                count--;
                intelligence -= buletPrice;

                if (bulets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bulets.Pop();
                if (count == 0 && bulets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = gunBarrel;
                    
                }
            }
            
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bulets.Count} bullets left. Earned ${intelligence}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
