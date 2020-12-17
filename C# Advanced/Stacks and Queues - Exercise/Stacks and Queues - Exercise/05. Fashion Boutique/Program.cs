using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rack = int.Parse(Console.ReadLine());
            
            Stack<int> clothes = new Stack<int>(input);
            int count = 0;


            while (clothes.Count > 0)
            {
                int rackCapacity = rack;

                while (clothes.Count > 0 && rackCapacity >= clothes.Peek() )
                {
                    rackCapacity -= clothes.Pop();
                }
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
