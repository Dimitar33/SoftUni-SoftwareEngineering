using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int toss = int.Parse(Console.ReadLine());
            
            Queue<string> kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                int n = toss;

                while (n > 0)
                {
                    if (n == 1)
                    {
                        Console.WriteLine($"Removed {kids.Dequeue()}");
                    }
                    else
                    {
                        
                        kids.Enqueue(kids.Dequeue());
                    }

                    n--;
                }

            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
