using System;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int life = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] maze = new char[n][];
            int y = 0;
            int x = 0;
            bool IsPrincessSaved = false;
            bool IsDead = false;
            char[] fill = null;
            for (int i = 0; i < n; i++)
            {
                fill = Console.ReadLine().ToCharArray();
                maze[i] = new char[fill.Length];
                for (int j = 0; j < fill.Length; j++)
                {
                    maze[i][j] = fill[j];
                    if (fill[j] == 'M')
                    {
                        y = i;
                        x = j;
                    }
                }
            }
            char[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char
                .Parse).ToArray();

            while (IsDead == false && IsPrincessSaved == false) // may be wrong
            {
                int browerRow = (int)char.GetNumericValue(cmd[1]);
                int browerCol = (int)char.GetNumericValue(cmd[2]);

                maze[browerRow][browerCol] = 'B';

                switch (cmd[0])
                {
                    case 'A':

                        life -= 1;
                        maze[y][x] = '-';
                        x -= 1;
                        if (x < 0)
                        {
                            x = 0;
                        }
                        if (maze[y][x] == 'B')
                        {
                            life -= 2;
                        }
                        else if (maze[y][x] == 'P')
                        {
                            maze[y][x] = '-';
                            IsPrincessSaved = true;
                            break;
                        }
                        if (life < 1)
                        {
                            IsDead = true;
                            maze[y][x] = 'X';
                            break;
                        }
                        maze[y][x] = 'M';

                        break;
                    case 'D':

                        life -= 1;
                        maze[y][x] = '-';
                        x += 1;
                        if (x >= fill.Length)
                        {
                            x -= 1;
                        }
                        if (maze[y][x] == 'B')
                        {
                            life -= 2;
                        }
                        else if (maze[y][x] == 'P')
                        {
                            maze[y][x] = '-';
                            IsPrincessSaved = true;
                            break;
                        }
                        if (life < 1)
                        {
                            IsDead = true;
                            maze[y][x] = 'X';
                            break;
                        }
                        maze[y][x] = 'M';
                        break;

                    case 'W':

                        life -= 1;
                        maze[y][x] = '-';
                        y -= 1;
                        if (y < 0)
                        {
                            y = 0;
                        }
                        if (maze[y][x] == 'B')
                        {
                            life -= 2;
                        }
                        else if (maze[y][x] == 'P')
                        {
                            maze[y][x] = '-';
                            IsPrincessSaved = true;
                            break;
                        }
                        if (life < 1)
                        {
                            IsDead = true;
                            maze[y][x] = 'X';
                            break;
                        }
                        maze[y][x] = 'M';

                        break;
                    case 'S':

                        life -= 1;
                        maze[y][x] = '-';
                        y += 1;
                        if (y >= maze.GetLength(0))
                        {
                            y -= 1;
                        }
                        if (maze[y][x] == 'B')
                        {
                            life -= 2;
                        }
                        else if (maze[y][x] == 'P')
                        {
                            maze[y][x] = '-';
                            IsPrincessSaved = true;
                            break;
                        }
                        if (life < 1)
                        {
                            IsDead = true;
                            maze[y][x] = 'X';
                            break;
                        }
                        maze[y][x] = 'M';
                        break;

                    default:
                        break;
                }
                if (IsDead || IsPrincessSaved)
                {
                    break;
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char
                .Parse).ToArray();
            }
            if (IsDead)
            {
                Console.WriteLine($"Mario died at {y};{x}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {life}");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < fill.Length; j++)
                {
                    Console.Write(maze[i][j]);
                }
                Console.WriteLine();
            }
        }

    }
}
