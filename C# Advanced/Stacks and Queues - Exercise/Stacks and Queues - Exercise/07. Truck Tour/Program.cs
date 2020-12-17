using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fuel = 0;
            Queue<string> pumps = new Queue<string>();
            

            for (int i = 0; i < n; i++)
            {
                string pump = Console.ReadLine();
                pumps.Enqueue(pump + " " + i);
            }
            for (int i = 0; i < n; i++)
            {

                int[] temp = pumps.Peek().Split().Select(int.Parse).ToArray();
                if (temp[0] + fuel < temp[1])
                {
                    pumps.Enqueue(pumps.Dequeue());
                    fuel = 0;
                    i = -1;
                }
                else
                {                    
                    fuel += temp[0];
                    fuel -= temp[1];
                    pumps.Enqueue(pumps.Dequeue());
                }
            }

            int[] first = pumps.Peek().Split().Select(int.Parse).ToArray();
            Console.WriteLine(first[2]);
        }
    }
}
