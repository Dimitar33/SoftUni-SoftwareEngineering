using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int count = 0;

            char[,] matrix = new char[data[0], data[1]];

            for (int i = 0; i < data[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < data[1]; j++)
                    {
                        matrix[i, j] = snake[count];
                        count++;
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < data[1]; j++)
                    {
                        matrix[i, matrix.GetLength(1) - 1 - j] = snake[count];
                        count++;

                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }


        }
        
    }
}
