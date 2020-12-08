using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> player2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            while (player1.Count > 0 && player2.Count > 0)
            {
                
                    if (player1[0] > player2[0])
                    {
                        player1.Add(player1[0]);
                        player1.Add(player2[0]);
                    }
                    if (player2[0] > player1[0])
                    {
                        player2.Add(player2[0]);
                        player2.Add(player1[0]);
                    }
                    player1.Remove(player1[0]);
                    player2.Remove(player2[0]);
                

            }
            if (player1.Sum() > 0)
            {
                Console.WriteLine($"First player wins! Sum: {player1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {player2.Sum()}");
            }
        }
    }
}
