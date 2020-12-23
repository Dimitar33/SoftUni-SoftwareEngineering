using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] matrix = new char[data[0], data[1]];
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) -1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) -1; j++)
                {
                    if (matrix[i,j] == matrix[i,j+1] && matrix[i, j] == matrix[i+1, j + 1] && matrix[i, j] == matrix[i+ 1, j])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
