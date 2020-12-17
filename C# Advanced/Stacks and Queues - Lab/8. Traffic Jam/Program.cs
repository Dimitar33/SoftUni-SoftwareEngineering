using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string cmd = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int count = 0;

            while (cmd != "end")
            {
                if (cmd != "green")
                {
                    cars.Enqueue(cmd);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
