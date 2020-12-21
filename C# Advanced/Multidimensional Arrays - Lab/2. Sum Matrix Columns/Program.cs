using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];                 
                }
            }
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                sum = 0;

                for (int cow = 0; cow < matrix.GetLength(0); cow++)
                {
                    sum += matrix[cow, row];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
