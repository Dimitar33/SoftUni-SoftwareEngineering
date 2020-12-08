using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._10_December_2019__Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] field = Console.ReadLine().Split("|").Select(int.Parse).ToArray();

            string end = Console.ReadLine();
            int points = 0;

            while (end != "Game over")
            {
                string[] cmd = end.Split('@');

                if (cmd[0] == "Reverse")
                {
                    field = field.Reverse().ToArray();
                    end = Console.ReadLine();
                    continue;
                }

                int start = int.Parse(cmd[1]);
                int distance = int.Parse(cmd[2]);

                if (start >= field.Length || start < 0)
                {
                    end = Console.ReadLine();
                    continue;
                }
                if (cmd[0] == "Shoot Right")
                {


                    while (distance > 0)
                    {
                        distance--;
                        if (start >= field.Length - 1)
                        {
                            start -= field.Length;
                        }
                        start++;
                    }
                    if (field[start] < 5)
                    {
                        points += field[start];
                        field[start] = 0;
                    }
                    else
                    {
                        field[start] -= 5;
                        points += 5;
                    }
                }
                else if (cmd[0] == "Shoot Left")
                {

                    while (distance > 0)
                    {
                        distance--;
                        start--;
                        if (start < 0)
                        {
                            start = field.Length - 1;
                        }
                    }

                    if (field[start] < 5)
                    {
                        points += field[start];
                        field[start] = 0;
                    }
                    else
                    {
                        field[start] -= 5;
                        points += 5;
                    }

                }

                end = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
