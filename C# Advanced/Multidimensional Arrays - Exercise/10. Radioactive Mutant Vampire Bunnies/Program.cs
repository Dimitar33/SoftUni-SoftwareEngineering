using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] field = new char[matrixSize[0], matrixSize[1]];
            int row = 0;
            int col = 0;


            for (int i = 0; i < matrixSize[0]; i++)
            {
                string filling = Console.ReadLine();

                for (int j = 0; j < filling.Length; j++)
                {
                    field[i, j] = filling[j];

                    if (filling[j] == 'P')
                    {
                        col = i;
                        row = j;
                    }
                }
            }

            string moves = Console.ReadLine().ToUpper();
            bool isDead = false;
            bool won = false;

            for (int k = 0; k < moves.Length; k++)
            {
                if (moves[k] == 'U')
                {
                    if (col - 1 < 0)
                    {
                        won = true;
                        field[col, row] = '.';

                    }
                    else if (col - 1 == 'B')
                    {
                        field[col - 1, row] = '.';
                        isDead = true;
                    }
                    else
                    {
                        field[col, row] = '.';
                        field[col - 1, row] = 'P';
                        col -= 1;
                    }
                }
                else if (moves[k] == 'D')
                {
                    if (col + 1 >= matrixSize.GetLength(1))
                    {
                        won = true;
                        field[col, row] = '.';
                    }
                    else if (col + 1 == 'B')
                    {
                        isDead = true;
                        field[col, row] = '.';
                    }
                    else
                    {
                        field[col, row] = '.';
                        field[col + 1, row] = 'P';
                        col += 1;
                    }
                }
                else if (moves[k] == 'L')
                {
                    if (row - 1 < 0)
                    {
                        won = true;
                        field[col, row] = '.';
                        
                    }
                    else if (row - 1 == 'B')
                    {
                        field[col, row] = '.';
                        isDead = true;
                    }
                    else
                    {
                        field[col, row] = '.';
                        field[col, row - 1] = 'P';
                        row -= 1;
                    }
                }
                else if (moves[k] == 'R')
                {
                    if (row + 1 >= matrixSize.GetLength(0))
                    {
                        won = true;
                        field[col, row] = '.';

                    }
                    else if (row + 1 == 'B')
                    {
                        isDead = true;
                        field[col, row] = '.';
                    }
                    else
                    {
                        field[col, row] = '.';
                        field[col, row + 1] = 'P';
                        row += 1;
                    }
                }
                char[,] newField = new char[matrixSize[0], matrixSize[1]];

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == 'B')
                        {
                            newField[i, j] = 'B';

                            if (i + 1 < newField.GetLength(0))
                            {
                                newField[i + 1, j] = 'B';
                            }
                            if (j + 1 < newField.GetLength(1))
                            {
                                newField[i, j + 1] = 'B';
                            }
                            if (i - 1 >= 0)
                            {
                                newField[i - 1, j] = 'B';
                            }
                            if (j - 1 >= 0)
                            {
                                newField[i, j - 1] = 'B';
                            }
                        }
                        if (field[i, j] == '.' && newField[i, j] != 'B' && newField[i, j] != 'P')
                        {
                            newField[i, j] = '.';
                        }
                        if (field[i, j] == 'P' && newField[i, j] == 'B')
                        {
                            newField[i, j] = 'B';
                            isDead = true;                            
                        }
                        else if (field[i, j] == 'P')
                        {
                            newField[i, j] = 'P';
                        }
                    }
                }
                field = newField;
                if (isDead)
                {
                    break;
                }
                if (won)
                {
                    break;
                }             

            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

            if (isDead)
            {
                Console.WriteLine($"dead: {col} {row}");
            }
            else
            {
                Console.WriteLine($"won: {col} {row}");
            }
        }
    }
}
