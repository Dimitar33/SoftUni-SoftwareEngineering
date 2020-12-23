using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[data[0], data[1]];

            fillMatrix(matrix);

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "END")
            {
                if (cmd.Length == 5)
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);

                    if (cmd[0] == "swap" &&
                        row1 >= 0 && row1 < matrix.GetLength(0) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col1 >= 0 && col1 < matrix.GetLength(1) &&
                        col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        printMatrix(matrix);
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                }
                Console.WriteLine("Invalid input!");
                cmd = Console.ReadLine().Split();
            }
        }

        private static void printMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void fillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
