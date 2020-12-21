using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;
            int bigest = 0;
            int row = 0;
            int pos = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];                    
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    sum = matrix[i, j] + matrix[i, j +1] + matrix[i +1,j] + matrix[i + 1, j +1];
                    if (bigest < sum)
                    {
                        bigest = sum;
                        row = i;
                        pos = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[row, pos]} {matrix[row, pos + 1]}");
            Console.WriteLine($"{matrix[row + 1, pos]} {matrix[row + 1, pos + 1]}");
            Console.WriteLine(bigest);
        }
    }
}
