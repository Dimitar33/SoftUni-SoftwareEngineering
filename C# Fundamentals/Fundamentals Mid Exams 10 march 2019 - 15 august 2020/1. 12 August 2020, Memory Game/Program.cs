using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._12_August_2020__Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string end = Console.ReadLine();
            int count = 0;

            while (end != "end")
            {
                count++;

                int[] cmd = end.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int first = cmd[0];
                int second = cmd[1];

                if ((first < 0 || first >= board.Count) || (second < 0 || second >= board.Count))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    board.Insert(board.Count / 2,"-"+ count + "a");
                    board.Insert(board.Count / 2, "-" + count + "a");
                }
                else if (board[first] == board[second])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {board[first]}!");
                    string elementToRemove = board[first];

                    board.RemoveAll(c => c == elementToRemove );
                    
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (board.Count == 0)
                {
                    Console.WriteLine($"You have won in {count} turns!");
                    Environment.Exit(0);
                }

                end = Console.ReadLine();
            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", board));
        }
    }
}
