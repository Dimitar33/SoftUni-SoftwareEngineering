using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string[] temp = Console.ReadLine().Split();
                Queue<string> comand = new Queue<string>(temp);
                string cmd = comand.Dequeue();
                string song = string.Join(" ", comand);

                switch (cmd)
                {
                    case "Play":

                        songs.Dequeue();

                        break;
                    case "Add":

                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }

                        break;
                    case "Show":

                        Console.WriteLine(string.Join(", ", songs));

                        break;

                    default:
                        break;
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}
