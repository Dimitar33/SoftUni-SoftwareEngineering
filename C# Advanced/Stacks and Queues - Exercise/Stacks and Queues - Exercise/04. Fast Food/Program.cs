using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Queue<int> queOrders = new Queue<int>(orders);
            Console.WriteLine(queOrders.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                if (food >= queOrders.Peek())
                {
                    food -= queOrders.Dequeue();                                       
                }
                else
                {
                    break;
                }
            }
            
            if (queOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queOrders)}");
            }
        }
    }
}
