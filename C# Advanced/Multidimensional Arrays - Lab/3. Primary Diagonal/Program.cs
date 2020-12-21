using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
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

                for (int cow = 0; cow < matrix.GetLength(0); cow++)
                {
                    sum += matrix[cow, row + cow];
                }
                break;
            }
            Console.WriteLine(sum);
        }
    }
}
