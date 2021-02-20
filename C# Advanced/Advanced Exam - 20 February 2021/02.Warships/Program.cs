using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            List<int> cmd = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int i = 0; i < n; i++)
            {
                char[] fill = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                for (int j = 0; j < fill.Length; j++)
                {
                    field[i, j] = fill[j];

                    if (fill[j] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (fill[j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }
            int totalShips1 = firstPlayerShips;
            int totalShops2 = secondPlayerShips;

            for (int i = 0; i < cmd.Count - 1; i+=2)
            {
                int col = cmd[i];
                int row = cmd[i + 1];

                if (col < 0 || col >= n || row < 0 || row >= n)
                {
                    continue;
                }

                if (field[col, row] == '>')
                {
                    field[col, row] = 'X';
                    secondPlayerShips--;
                }
                else if (field[col, row] == '<')
                {
                    field[col, row] = 'X';
                    firstPlayerShips--;
                }
                else if (field[col, row] == '#')
                {

                    if (col + 1 < n)
                    {
                        if (field[col + 1, row] == '>')
                        {
                            field[col + 1, row] = 'X';
                            secondPlayerShips--;
                        }
                        else if (field[col + 1, row] == '<')
                        {
                            field[col + 1, row] = 'X';
                            firstPlayerShips--;
                        }
                    }

                    if (col - 1 > 0)
                    {
                        if (field[col - 1, row] == '>')
                        {
                            field[col - 1, row] = 'X';
                            secondPlayerShips--;
                        }
                        else if (field[col - 1, row] == '<')
                        {
                            field[col - 1, row] = 'X';
                            firstPlayerShips--;
                        }
                    }

                    if (row + 1 < n)
                    {
                        if (field[col, row + 1] == '>')
                        {
                            field[col, row + 1] = 'X';
                            secondPlayerShips--;
                        }
                        else if (field[col, row + 1] == '<')
                        {
                            field[col, row + 1] = 'X';
                            firstPlayerShips--;
                        }
                    }

                    if ( row - 1 > 0)
                    {
                        if (field[col, row - 1] == '>')
                        {
                            field[col, row - 1] = 'X';
                            secondPlayerShips--;

                        }
                        else if (field[col, row - 1] == '<')
                        {
                            field[col, row - 1] = 'X';
                            firstPlayerShips--;
                        }
                    }



                    if (col + 1 < n && row + 1 < n)
                    {
                        if (field[col + 1, row + 1] == '>')
                        {
                            field[col + 1, row + 1] = 'X';
                            secondPlayerShips--;

                        }
                        else if (field[col + 1, row + 1] == '<')
                        {
                            field[col + 1, row + 1] = 'X';
                            firstPlayerShips--;
                        }
                    }

                    if (col - 1 > 0 &&  row + 1 < n)
                    {
                        if (field[col - 1, row + 1] == '>')
                        {
                            field[col - 1, row + 1] = 'X';
                            secondPlayerShips--;

                        }
                        else if (field[col - 1, row + 1] == '<')
                        {
                            field[col - 1, row + 1] = 'X';
                            firstPlayerShips--;
                        }
                    }

                    if (col - 1 > 0 &&  row - 1 > 0)
                    {
                        if (field[col - 1, row - 1] == '>')
                        {
                            field[col - 1, row - 1] = 'X';
                            secondPlayerShips--;

                        }
                        else if (field[col - 1, row - 1] == '<')
                        {
                            field[col - 1, row - 1] = 'X';
                            firstPlayerShips--;
                        }
                    }


                    if (col + 1 < n && row - 1 > 0 )
                    {
                        if (field[col + 1, row - 1] == '>')
                        {
                            field[col + 1, row - 1] = 'X';
                            secondPlayerShips--;

                        }
                        else if (field[col + 1, row - 1] == '<')
                        {
                            field[col + 1, row - 1] = 'X';
                            firstPlayerShips--;
                        }
                    }
                    
                }

                if (firstPlayerShips == 0 || secondPlayerShips == 0)
                {
                    break;
                }
            }
            if (firstPlayerShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips1 + totalShops2 - firstPlayerShips - secondPlayerShips} ships have been sunk in the battle.");
            }
            else if (secondPlayerShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips1 + totalShops2 - firstPlayerShips - secondPlayerShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }
    }
}
