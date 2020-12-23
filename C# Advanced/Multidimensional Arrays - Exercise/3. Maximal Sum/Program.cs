using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[data[0], data[1]];
            int sum = 0;
            int bestSum = 0;
            int colIndex = 0;
            int rolIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 2, j] + matrix[i + 1, j + 1] + matrix[i + 2, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        rolIndex = i;
                        colIndex = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");

            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine($"{matrix[rolIndex + i ,colIndex]} {matrix[rolIndex +i, colIndex + 1]} {matrix[rolIndex + i, colIndex + 2]}");

            }
        }
    }
}
