using System;
using System.Collections.Generic;
using System.Linq;

namespace _1112.ArrManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command.Split();
                string operation = cmdArg[0];

                switch (operation)
                {
                    case "exchange":
                        int index = int.Parse(cmdArg[1]);

                        if (index < 0 || index >= input.Count)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        else
                        {
                            for (int i = 0; i <= index; i++)
                            {
                                int tempElement = input[0];
                                input.Add(tempElement);
                                input.RemoveAt(0);
                            }
                        }

                        break;

                    case "max":
                        int maxIndex = -1;
                        int maxValue = int.MinValue;
                        bool noMatches = true;

                        switch (cmdArg[1])
                        {
                            case "even":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (input[i] % 2 == 0 && input[i] >= maxValue)
                                    {
                                        maxIndex = i;
                                        maxValue = input[i];
                                        noMatches = false;
                                    }
                                }

                                if (noMatches)
                                {
                                    Console.WriteLine("No matches");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(maxIndex);
                                    continue;
                                }
                                break;

                            case "odd":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (input[i] % 2 != 0 && input[i] >= maxValue)
                                    {
                                        maxIndex = i;
                                        maxValue = input[i];
                                        noMatches = false;
                                    }
                                }

                                if (noMatches)
                                {
                                    Console.WriteLine("No matches");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(maxIndex);
                                    continue;
                                }
                                break;
                        }
                        break;
                    case "min":
                        int minIndex = -1;
                        int minValue = int.MaxValue;
                        bool noMinMatches = true; ;

                        switch (cmdArg[1])
                        {
                            case "even":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (input[i] % 2 == 0 && input[i] <= minValue)
                                    {
                                        minIndex = i;
                                        minValue = input[i];
                                        noMinMatches  = false;
                                    }
                                }

                                if (noMinMatches)
                                {
                                    Console.WriteLine("No matches");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(minIndex);
                                    continue;
                                }
                                break;

                            case "odd":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (input[i] % 2 != 0 && input[i] <= minValue)
                                    {
                                        minIndex = i;
                                        minValue = input[i];
                                        noMinMatches = false;
                                    }
                                }

                                if (noMinMatches)
                                {
                                    Console.WriteLine("No matches");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine(minIndex);
                                    continue;
                                }
                                break;
                        }
                        break;

                    case "first":

                        int countFirst = int.Parse(cmdArg[1]);
                        if (countFirst > input.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        List<int> firstCountElements = new List<int>();

                        switch (cmdArg[2])
                        {
                            case "even":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (countFirst == 0)
                                    {
                                        break;
                                    }
                                    else if (input[i] %2 ==0)
                                    {
                                        firstCountElements.Add(input[i]);
                                        countFirst--;
                                    }
                                }
                                break;

                            case "odd":

                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (countFirst == 0)
                                    {
                                        break;
                                    }
                                    else if (input[i] % 2 != 0)
                                    {
                                        firstCountElements.Add(input[i]);
                                        countFirst--;
                                    }
                                }
                                break;
                        }

                        Console.WriteLine($"[{string.Join(", ", firstCountElements)}]");
                        break;

                    case "last":
                        int countLast = int.Parse(cmdArg[1]);
                        if (countLast > input.Count)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        List<int> lastCountElements = new List<int>();

                       
                        switch (cmdArg[2])
                        {
                            case "even":
                                input.Reverse();
                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (countLast == 0)
                                    {
                                        break;
                                    }
                                    else if (input[i] % 2 == 0)
                                    {
                                        lastCountElements.Add(input[i]);
                                        countLast--;
                                    }
                                }
                                break;

                            case "odd":
                                input.Reverse();
                                for (int i = 0; i < input.Count; i++)
                                {
                                    if (countLast == 0)
                                    {
                                        break;
                                    }
                                    else if (input[i] % 2 != 0)
                                    {
                                        lastCountElements.Add(input[i]);
                                        countLast--;
                                    }
                                }
                                break;
                        }
                        input.Reverse();
                        lastCountElements.Reverse();
                        Console.WriteLine($"[{string.Join(", ", lastCountElements)}]");
                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", input)}]");
        }
    }
}
