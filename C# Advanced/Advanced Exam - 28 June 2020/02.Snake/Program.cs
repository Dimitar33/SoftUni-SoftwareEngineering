using System;
using System.Collections.Generic;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int col = 0;
            int row = 0;
            int food = 0;
            bool isOut = false;

            List<Tuple<int, int>> holes = new List<Tuple<int, int>>();

            for (int i = 0; i < n; i++)
            {
                char[] fill = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = fill[j];

                    if (fill[j] == 'S')
                    {
                        col = i;
                        row = j;
                    }
                    if (fill[j] == 'B')
                    {
                        holes.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            string moves = Console.ReadLine();

            while (food < 10 && isOut == false)
            {
                if (moves == "up" && col > 0)
                {
                    field[col, row] = '.';
                    col--;

                    if (field[col, row] == 'B')
                    {
                        field[col, row] = '.';
                        if (col == holes[0].Item1 && row == holes[0].Item2)
                        {
                            col = holes[1].Item1;
                            row = holes[1].Item2;
                        }
                        else
                        {
                            col = holes[0].Item1;
                            row = holes[0].Item2;
                        }
                    }
                    else if (field[col, row] == '*')
                    {
                        food++;
                    }
                    field[col, row] = 'S';
                }
                else if (moves == "down" && col < field.GetLength(0) - 1)
                {
                    field[col, row] = '.';
                    col++;

                    if (field[col, row] == 'B')
                    {
                        field[col, row] = '.';
                        if (col == holes[0].Item1 && row == holes[0].Item2)
                        {
                            col = holes[1].Item1;
                            row = holes[1].Item2;
                        }
                        else
                        {
                            col = holes[0].Item1;
                            row = holes[0].Item2;
                        }
                    }
                    else if (field[col, row] == '*')
                    {
                        food++;
                    }
                    field[col, row] = 'S';
                }
                else if (moves == "left" && row > 0)
                {
                    field[col, row] = '.';
                    row--;

                    if (field[col, row] == 'B')
                    {
                        field[col, row] = '.';
                        if (col == holes[0].Item1 && row == holes[0].Item2)
                        {
                            col = holes[1].Item1;
                            row = holes[1].Item2;
                        }
                        else
                        {
                            col = holes[0].Item1;
                            row = holes[0].Item2;
                        }
                    }
                    else if (field[col, row] == '*')
                    {
                        food++;
                    }
                    field[col, row] = 'S';
                }
                else if (moves == "right" && row < field.GetLength(0) - 1)
                {
                    field[col, row] = '.';
                    row++;

                    if (field[col, row] == 'B')
                    {
                        field[col, row] = '.';
                        if (col == holes[0].Item1 && row == holes[0].Item2)
                        {
                            col = holes[1].Item1;
                            row = holes[1].Item2;
                        }
                        else
                        {
                            col = holes[0].Item1;
                            row = holes[0].Item2;
                        }
                    }
                    else if (field[col, row] == '*')
                    {
                        food++;
                    }
                    field[col, row] = 'S';
                }
                else
                {
                    field[col, row] = '.';
                    isOut = true;
                }
                moves = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
