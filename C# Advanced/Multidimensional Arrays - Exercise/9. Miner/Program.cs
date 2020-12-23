using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine().Split();
            int x = 0;
            int y = 0;
            int coal = 0;

            char[,] field = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] filling = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = filling[j];

                    if (filling[j] == 's')
                    {
                        x = i;
                        y = j;
                    }
                    if (filling[j] == 'c')
                    {
                        coal++;
                    }
                }
            }

            int colectedCoal = 0;
            bool flag = false;

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == "left" && y - 1 >= 0)
                {
                    if (field[x, y - 1] == 'c')
                    {
                        colectedCoal++;
                        field[x, y - 1] = '*';
                        coal--;
                    }
                    else if (field[x, y - 1] == 'e')
                    {
                        flag = true;
                        y--;
                        break;
                    }
                    y--;
                }
                else if (moves[i] == "right" && y + 1 < n)
                {
                    if (field[x, y + 1] == 'c')
                    {
                        colectedCoal++;
                        field[x, y + 1] = '*';
                        coal--;
                    }
                    else if (field[x, y + 1] == 'e')
                    {
                        flag = true;
                        y++;
                        break;
                    }
                    y++;
                }
                else if (moves[i] == "up" && x - 1 >= 0)
                {
                    if (field[x - 1, y] == 'c')
                    {
                        colectedCoal++;
                        coal--;
                        field[x - 1, y] = '*';
                    }
                    else if (field[x - 1, y] == 'e')
                    {
                        flag = true;
                        x--;
                        break;
                    }
                    x--;
                }
                else if (moves[i] == "down" && x + 1 < n)
                {
                    if (field[x + 1, y] == 'c')
                    {
                        colectedCoal++;
                        field[x + 1, y] = '*';
                        coal--;
                    }
                    else if (field[x + 1, y] == 'e')
                    {
                        flag = true;
                        x++;
                        break;
                    }
                    x++;
                }
                if (coal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({x}, {y})");
                    Environment.Exit(0);
                }
            }
            if (flag)
            {
                Console.WriteLine($"Game over! ({x}, {y})");
            }
            else
            {
                Console.WriteLine($"{coal} coals left. ({x}, {y})");
            }
        }
    }
}
