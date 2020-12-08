using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(",").Select(c => c.Trim()).ToArray();

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length == 20)
                {
                    var left = Regex.Match(tickets[i].Substring(0, 10), @"[@]{6,}|[#]{6,}|[$]{6,}|[\^]{6,}");
                    var right = Regex.Match(tickets[i].Substring(10), @"[@]{6,}|[#]{6,}|[$]{6,}|[\^]{6,}");

                    if (left.Success && right.Success)
                    {
                        int count = Math.Min(left.Length, right.Length);

                        char chLeft = 'a';
                        char chRight = 'a';

                        foreach (var item in right.Value)
                        {
                            chRight = item;
                            break;
                        }
                        foreach (var item in left.Value)
                        {
                            chLeft = item;
                            break;
                        }
                        if (chRight == chLeft)
                        {
                            if (left.Length == 10 && right.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{tickets[i]}\" - {count}{chRight} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{tickets[i]}\" - {count}{chRight}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");

                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
