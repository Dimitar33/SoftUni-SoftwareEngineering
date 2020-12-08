using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            

            while (command[0] != "end")
            {
                
                if (command[0] == "Add")
                {
                    train.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < train.Count; i++)
                    {
                        bool isFlag = false;

                        if (int.Parse(command[0]) + train[i] <= capacity)
                        {
                            train[i] += int.Parse(command[0]);
                            isFlag = true;
                            break;
                        }
                        if (isFlag)
                        {
                            train.Add(int.Parse(command[0]));
                        }
                    }
                    

                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", train));
        }
    }
}

