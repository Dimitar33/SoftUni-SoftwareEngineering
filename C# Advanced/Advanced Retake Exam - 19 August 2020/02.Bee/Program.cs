using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int col = 0;
            int row = 0;
            int flowers = 0;
            bool isOut = false;

            for (int i = 0; i < n; i++)
            {
                char[] fill = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = fill[j];
                    if (fill[j] == 'B')
                    {
                        col = i;
                        row = j;
                    }
                }
            }

            string moves = Console.ReadLine();

            while (moves != "End" && isOut == false)
            {
                if (moves == "up" && col > 0)
                {
                    field[col, row] = '.';
                    col--;

                    if (field[col, row] == 'O')
                    {
                        field[col, row] = '.';
                        col--;
                        if (field[col, row] == 'f')
                        {
                            flowers++;
                        }
                    }
                    else if (field[col, row] == 'f')
                    {
                        flowers++;
                    }
                    field[col, row] = 'B';

                }
                else if (moves == "down" && col < field.GetLength(0) - 1)
                {
                    field[col, row] = '.';
                    col++;
                    if (field[col, row] == 'O')
                    {
                        field[col, row] = '.';
                        col++;
                        if (field[col, row] == 'f')
                        {
                            flowers++;
                        }

                    }
                    else if (field[col, row] == 'f')
                    {
                        flowers++;
                    }
                    field[col, row] = 'B';

                }
                else if (moves == "left" && row > 0)
                {
                    field[col, row] = '.';
                    row--;
                    if (field[col, row] == 'O')
                    {
                        field[col, row] = '.';
                        row--;
                        if (field[col, row] == 'f')
                        {
                            flowers++;
                        }
                    }
                    else if (field[col, row] == 'f')
                    {
                        flowers++;
                    }
                    field[col, row] = 'B';

                }
                else if (moves == "right" && row < field.GetLength(0) - 1)
                {
                    field[col, row] = '.';
                    row++;
                    if (field[col, row] == 'O')
                    {
                        field[col, row] = '.';
                        row++;
                        if (field[col, row] == 'f')
                        {
                            flowers++;
                        }
                        
                    }
                    else if (field[col, row] == 'f')
                    {
                        flowers++;
                    }
                    field[col, row] = 'B';

                }
                else
                {
                    field[col, row] = '.';
                    isOut = true;
                    Console.WriteLine("The bee got lost!");
                }

                moves = Console.ReadLine();
            }

            if (flowers > 4)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {               
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }

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
